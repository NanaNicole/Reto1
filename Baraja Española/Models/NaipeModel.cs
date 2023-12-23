using System.ComponentModel.DataAnnotations;

namespace Baraja_Española.Models
{
    public class NaipeModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Palo { get; set; }
    }
}
