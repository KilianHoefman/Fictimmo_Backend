using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Models
{        
    public class ImmoBureau
    {       
        private string _naam;
        public string Naam {
            get
            {
                return _naam;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Immobureau moet een naam hebben en deze mag niet leeg zijn");
            }
        }
        public ICollection<Huis> Huizen;

        public ImmoBureau()
        {
            Huizen = new List<Huis>();
        }

        public ImmoBureau(string naam) : this()
        {
            Naam = naam;
        }
    }
}
