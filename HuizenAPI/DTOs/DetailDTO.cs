using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.DTOs
{
    public class DetailDTO
    {
        public string LangeBeschrijving { get; set; }
        public int BewoonbareOppervlakte { get; set; }
        public int TotaleOppervlakte { get; set; }
        public int EPCWaarde { get; set; }
        public int KadastraalInkomen { get; set; }
    }
}
