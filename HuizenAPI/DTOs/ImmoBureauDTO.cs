using System.ComponentModel.DataAnnotations;

namespace HuizenAPI.DTOs
{
    public class ImmoBureauDTO
    {
        [Required]
        public string Naam { get; set; }
    }
}