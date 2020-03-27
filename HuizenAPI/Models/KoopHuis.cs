using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.Models
{
    public class KoopHuis : ITypeHuis
    {
        public double GetPrice()
        {
            return 450000;
        }

        public string GetTypeHuis()
        {
            return "Koop";
        }
    }
}
