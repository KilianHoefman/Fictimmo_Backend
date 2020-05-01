using System.ComponentModel.DataAnnotations;

namespace HuizenAPI.DTOs
{
    public class HuisDTO
    {
        [Required]
        public LocatieDTO Locatie { get; set; }
        [Required]
        public string KorteBeschrijving { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DetailDTO Detail { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Soort { get; set; }
        [Required]
        public ImmoBureauDTO ImmoBureau { get; set; }
    }
}