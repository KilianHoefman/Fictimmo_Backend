using System.Collections.Generic;

namespace HuizenAPI.Models
{
    public interface ILocatieRepository
    {
        Locatie GetById(int id);
        IEnumerable<Locatie> GetAll();
        IEnumerable<Locatie> GetBy(string gemeente = null, string straatnaam = null, string huisnummer = null, int? postcode = null);
        void Add(Locatie locatie);
        void Delete(Locatie locatie);
        void Update(Locatie locatie);
        void SaveChanges();
    }
}
