using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.DTOs
{
    public class KlantDTO
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        //public DateTime GeboorteDatum { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
    }
}
