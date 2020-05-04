using System.Collections.Generic;

namespace HuizenAPI.Models
{
    public interface IKlantRepository
    {
        Klant GetById(int id);
        IEnumerable<Klant> GetAll();
        IEnumerable<Klant> GetBy(string voornaam = null, string achternaam = null, string email = null);
        Klant GetByEmail(string email);
        void Add(Klant klant);
        void Delete(Klant klant);
        void Update(Klant klant);
        void SaveChanges();
    }
}
