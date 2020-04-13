using System.ComponentModel.DataAnnotations;

namespace HuizenAPI.DTOs
{
    public class HuisDTO
    {
        [Required]
        public LocatieDTO LocatieDTO { get; set; }
        [Required]
        public string KorteBeschrijving { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DetailDTO DetailDTO { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Soort { get; set; }
        [Required]
        public ImmoBureauDTO ImmoBureauDTO { get; set; }
    }
}
