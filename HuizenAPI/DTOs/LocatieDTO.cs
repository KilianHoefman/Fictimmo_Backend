using System.ComponentModel.DataAnnotations;

namespace HuizenAPI.DTOs
{
    public class LocatieDTO
    {
        [Required]
        public string Gemeente { get; set; }
        [Required]
        public string Straatnaam { get; set; }
        [Required]
        public string Huisnummer { get; set; }
        [Required]
        public int Postcode { get; set; }
    }
}