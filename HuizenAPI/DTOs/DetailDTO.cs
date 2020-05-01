using System.ComponentModel.DataAnnotations;

namespace HuizenAPI.DTOs
{
    public class DetailDTO
    {
        [Required]
        public string LangeBeschrijving { get; set; }
        [Required]
        public int BewoonbareOppervlakte { get; set; }
        [Required]
        public int TotaleOppervlakte { get; set; }
        [Required]
        public int EPCWaarde { get; set; }
        [Required]
        public int KadastraalInkomen { get; set; }
    }
}