using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.DTOs
{
    public class LocatieDTO
    {
        public string Gemeente { get; set; }
        public string Straatnaam { get; set; }
        public string Huisnummer { get; set; }
        public int Postcode { get; set; }
    }
}
