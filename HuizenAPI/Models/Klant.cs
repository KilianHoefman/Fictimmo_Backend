using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public class Klant
    {
        public int KlantenNummer { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Password { get; set; }
    }
}
