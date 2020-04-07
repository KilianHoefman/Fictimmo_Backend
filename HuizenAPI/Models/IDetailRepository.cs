using System.Collections.Generic;

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
