using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public class Huis
    {
        public int Id { get; set; }
        public Locatie Locatie { get; set; }
        public String KorteBeschrijving { get; set; }
        public double Price { get; set; }
        public Detail Details { get; set; }
        public Status Status { get; set; }
    }
}
