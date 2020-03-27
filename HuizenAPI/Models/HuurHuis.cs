using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.Models
{
    public class HuurHuis : ITypeHuis
    {
        public double GetPrice()
        {
            return 750;
        }

        public string GetTypeHuis()
        {
            return "Huur";
        }
    }
}
