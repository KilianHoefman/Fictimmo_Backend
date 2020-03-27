using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.Models
{
    public abstract class TypeHuis
    {
        public abstract string GetTypeHuis();
        public abstract double GetPrice();
        public abstract string GetStatus();
        
    }
}
