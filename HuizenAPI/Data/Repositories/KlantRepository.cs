using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Data.Repositories
{
    public class KlantRepository : IKlantRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Klant> _klanten;

        public KlantRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _klanten = dbContext.Klant;
        }

        public void Add(Klant klant)
        {
            _klanten.Add(klant);
        }

        public void Delete(Klant klant)
        {
            _klanten.Remove(klant);
        }

        public IEnumerable<Klant> GetAll()
        {
            return _klanten.ToList();
        }

        public IEnumerable<Klant> GetBy(string voornaam = null, string achternaam = null, string email = null, string telefoonNummer = null)
        {
            var klanten = _klanten.AsQueryable();
            if (!string.IsNullOrEmpty(voornaam))
                klanten = klanten.Where(k => k.Voornaam.IndexOf(voornaam) >= 0);
            if (!string.IsNullOrEmpty(achternaam))
                klanten = klanten.Where(k => k.Achternaam.IndexOf(achternaam) >= 0);
            if (!string.IsNullOrEmpty(email))
                klanten = klanten.Where(k => k.Email.IndexOf(email) >= 0);
            if (!string.IsNullOrEmpty(telefoonNummer))
                klanten = klanten.Where(k => k.TelefoonNummer.IndexOf(telefoonNummer) >= 0);
            return klanten.OrderBy(r => r.Achternaam).ToList();
        }
                
        public Klant GetById(int id)
        {
            return _klanten.SingleOrDefault(k => k.KlantenNummer == id);
        }
        public Klant GetByImmoBureau(ImmoBureau immoBureau)
        {
            return _klanten.SingleOrDefault(k => k.ImmoBureau == immoBureau);
        }

        public void Update(Klant klant)
        {
            _context.Update(klant);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
