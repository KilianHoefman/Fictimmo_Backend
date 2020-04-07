using System.Collections.Generic;

namespace HuizenAPI.Models
{
    public interface IKlantRepository
    {
        Klant GetById(int id);
        Klant GetByImmoBureau(ImmoBureau immoBureau);
        IEnumerable<Klant> GetAll();
        IEnumerable<Klant> GetBy(string voornaam = null, string achternaam = null, string email = null, string telefoonNummer = null);
        Klant GetByEmail(string email);
        IEnumerable<Favorieten> GetFavorieten(Klant klant);
        void Add(Klant klant);
        void Delete(Klant klant);
        void Update(Klant klant);
        void SaveChanges();
    }
}
