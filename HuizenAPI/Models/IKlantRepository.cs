using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Models
{
    interface IKlantRepository
    {
        Klant GetById(int id);
        Klant GetByImmoBureau(ImmoBureau immoBureau);
        IEnumerable<Klant> GetAll();
        IEnumerable<Klant> GetBy(string voornaam = null, string achternaam = null, string email = null, string telefoonNummer = null);
        void Add(Klant klant);
        void Delete(Klant klant);
        void Update(Klant klant);
        void SaveChanges();
    }
}
