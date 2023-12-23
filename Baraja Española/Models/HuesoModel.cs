using System.ComponentModel.DataAnnotations;

namespace Baraja_Española.Models
{
    public class HuesoModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public double Peso { get; set; }

        [Required]
        public double Densidad { get; set; }

        [Required]
        public double Longitud { get; set; }

        [Required]
        public double Diametro { get; set; }
    }
}
