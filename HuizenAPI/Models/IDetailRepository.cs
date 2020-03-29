using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Models
{
    public interface IDetailRepository
    {
        Detail GetById(int id);
        IEnumerable<Detail> GetAll();
        IEnumerable<Detail> GetBy(int? bewoonbareOppervlakte = null, int? totaleOppervlakte = null, int? epcWaarde = null, int? kadastraalInkomen = null);
        void Add(Detail detail);
        void Delete(Detail detail);
        void Update(Detail detail);
        void SaveChanges();
    }
}
