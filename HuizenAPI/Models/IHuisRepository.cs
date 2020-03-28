using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Models
{
    public interface IHuisRepository
    {
        Huis GetById(int id);
        IEnumerable<Huis> GetAll();
        IEnumerable<Huis> GetBy(Locatie locatie = null, int? price = null, string type = null, ImmoBureau immoBureau = null);
        void Add(Huis huis);
        void Delete(Huis huis);
        void Update(Huis huis);
        void SaveChanges();
    }
}
