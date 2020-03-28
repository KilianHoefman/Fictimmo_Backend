using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.Models
{
    interface IImmoBureauRepository
    {
        ImmoBureau GetById(int id);
        IEnumerable<ImmoBureau> GetAll();
        IEnumerable<ImmoBureau> GetBy(string naam);
        void Add(ImmoBureau immoBureau);
        void Delete(ImmoBureau immoBureau);
        void Update(ImmoBureau immoBureau);
        void SaveChanges();
    }
}
