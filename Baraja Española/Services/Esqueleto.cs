using Baraja_Española.Models;
using static Azure.Core.HttpHeader;

namespace Baraja_Española.Services
{
    public class Esqueleto
    {
        private HuesoModel[] huesos;

        public Esqueleto()
        {
            huesos = new HuesoModel[206];
        }

        // Método para obtener la colección de huesos
        public HuesoModel[] GetHuesos()
        {
            // Filtrar los elementos no nulos del arreglo de huesos
            return huesos.Where(h => h != null).ToArray();
        }

        // Método para cargar la información de los huesos
        public void CargarInformacion(int indice, string nombre, double peso, double densidad, double longitud, double diametro)
        {
            huesos[indice] = new HuesoModel
            {
                Nombre = nombre,
                Peso = peso,
                Densidad = densidad,
                Longitud = longitud,
                Diametro = diametro
            };
        }

        // Método para ordenar e imprimir los huesos según el criterio seleccionado
        public void OrdenarEImprimir(string criterio)
        {
            switch (criterio.ToLower())
            {
                case "nombre":
                    huesos = huesos.OrderBy(h => h.Nombre).ToArray();
                    break;
                case "peso":
                    huesos = huesos.OrderBy(h => h.Peso).ToArray();
                    break;
                case "densidad":
                    huesos = huesos.OrderBy(h => h.Densidad).ToArray();
                    break;
                case "longitud":
                    huesos = huesos.OrderBy(h => h.Longitud).ToArray();
                    break;
                case "diametro":
                    huesos = huesos.OrderBy(h => h.Diametro).ToArray();
                    break;
                default:
                    Console.WriteLine("Criterio no válido");
                    return;
            }

            // Imprimir los huesos ordenados
            Console.WriteLine($"{"Nombre",-15} {"Peso",-10} {"Densidad",-10} {"Longitud",-10} {"Diametro",-10}");
            foreach (var hueso in huesos)
            {
                Console.WriteLine($"{hueso.Nombre,-15} {hueso.Peso,-10} {hueso.Densidad,-10} {hueso.Longitud,-10} {hueso.Diametro,-10}");
            }
        }
        public void GuardarEnArchivo(Esqueleto esqueleto)
        {
            string filePath = "esqueleto.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var hueso in esqueleto.GetHuesos())
                    {
                        writer.WriteLine($"{hueso.Nombre},{hueso.Peso},{hueso.Densidad},{hueso.Longitud},{hueso.Diametro}");
                    }
                }

                Console.WriteLine($"La información se ha guardado en el archivo: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo: {ex.Message}");
            }
        }
        // Método para cargar la información desde un archivo
        public void CargarDesdeArchivo(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int index = 0;

                    while ((line = reader.ReadLine()) != null && index < huesos.Length)
                    {
                        string[] parts = line.Split(',');

                        // Convertir las partes a los tipos correspondientes
                        string nombre = parts[0];
                        double peso = Convert.ToDouble(parts[1]);
                        double densidad = Convert.ToDouble(parts[2]);
                        double longitud = Convert.ToDouble(parts[3]);
                        double diametro = Convert.ToDouble(parts[4]);

                        // Cargar la información en el hueso correspondiente
                        CargarInformacion(index, nombre, peso, densidad, longitud, diametro);

                        index++;
                    }
                }

                Console.WriteLine($"La información se ha cargado desde el archivo: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }
        }

    }
}
