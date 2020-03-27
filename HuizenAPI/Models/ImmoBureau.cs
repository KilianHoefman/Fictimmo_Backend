using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.Models
{
    public class ImmoBureau
    {
        public string Naam { get; set; }
        public ICollection<HuurHuis> HuurHuizen;
        public ICollection<KoopHuis> KoopHuizen;

        public ImmoBureau()
        {
            HuurHuizen = new List<HuurHuis>();
            KoopHuizen = new List<KoopHuis>();
        }

        public ImmoBureau(string naam) : this()
        {
            Naam = naam;
        }
    }
}
