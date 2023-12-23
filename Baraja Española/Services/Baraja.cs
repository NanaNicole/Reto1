using Baraja_Española.Models;
using Baraja_Española.Services.Interfaces;

namespace Baraja_Española.Services
{
    public class Baraja: IBaraja
    {
        private List<Naipe> naipes;
        public Baraja()
        {
            naipes = new List<Naipe>();
            InicializarNaipes();
        }
        public void InicializarNaipes()
        {
            string[] palos = { "oros", "copas", "espadas", "bastos" };

            foreach (var palo in palos)
            {
                for (int numero = 1; numero <= 12; numero++)
                {
                    NaipeModel naipe = new NaipeModel {
                        Numero = numero,
                        Palo = palo
                    };                
                    naipes.Add(new Naipe(naipe));
                }
            }
        }

        public void Ordenar()
        {
            naipes.Sort((naipe1, naipe2) =>
            {
                int comparacionPalo = String.Compare(naipe1.Palo, naipe2.Palo, StringComparison.Ordinal);
                if (comparacionPalo == 0)
                {
                    return naipe1.Numero.CompareTo(naipe2.Numero);
                }
                return comparacionPalo;
            });
        }

        public void Barajar()
        {
            Random random = new Random();
            int n = naipes.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Naipe value = naipes[k];
                naipes[k] = naipes[n];
                naipes[n] = value;
            }
        }

        public void Imprimir()
        {
            foreach (var naipe in naipes)
            {
                Console.WriteLine($"{naipe.Numero} de {naipe.Palo}");
            }
        }

        public List<Naipe> ObtenerBaraja()
        {
            return naipes;
        }

        public void GuardarEnArchivo(string rutaArchivo)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                foreach (var naipe in naipes)
                {
                    writer.WriteLine($"{naipe.Numero} de {naipe.Palo}");
                }
            }
        }

        public void LeerDesdeArchivo(string rutaArchivo)
        {
            naipes = new List<Naipe>();

            try
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        try
                        {
                            Naipe naipe = Naipe.CrearDesdeString(linea);
                            naipes.Add(naipe);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Error al procesar línea en el archivo: {ex.Message}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer desde el archivo: {ex.Message}");
            }
        }
    }
}
