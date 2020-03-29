using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

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
