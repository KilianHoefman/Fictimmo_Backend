using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Models
{
    interface IDetailRepository
    {
        Detail GetById(int id);
        IEnumerable<Detail> GetAll();
        IEnumerable<Detail> GetBy(int? bewoonbareOppervlakte = null, int? totaleOppervlakte = null, int? epcWaarde = null, int? kadastraalInkomen = null);
        void Add(Detail details);
        void Delete(Detail details);
        void Update(Detail details);
        void SaveChanges();
    }
}
