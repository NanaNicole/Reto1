using Baraja_Española.Models;

namespace Baraja_Española.Services
{
    public class Naipe
    {
        public int Numero;
        public string Palo;

        public Naipe(NaipeModel naipe)
        {
            Numero = naipe.Numero;
            Palo = naipe.Palo;
        }

        public static Naipe CrearDesdeString(string naipeString)
        {
            string[] partes = naipeString.Split(' ');
            if (partes.Length == 3 && int.TryParse(partes[0], out int numero))
            {
                NaipeModel naipe = new NaipeModel
                {
                    Numero = numero,
                    Palo = partes[2]
                };
                return new Naipe(naipe);
            }

            throw new FormatException("Formato de naipe no válido en la cadena.");
        }
    }
}
