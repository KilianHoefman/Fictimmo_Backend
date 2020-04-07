using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HuizenAPI.Data.Repositories
{
    public class LocatieRepository : ILocatieRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Locatie> _locaties;

        public LocatieRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _locaties = dbContext.Locatie;
        }

        public void Add(Locatie locatie)
        {
            _locaties.Add(locatie);
        }

        public void Delete(Locatie locatie)
        {
            _locaties.Remove(locatie);
        }

        public IEnumerable<Locatie> GetAll()
        {
            return _locaties.OrderBy(l => l.Gemeente).ToList();
        }

        public IEnumerable<Locatie> GetBy(string gemeente = null, string straatnaam = null, string huisnummer = null, int? postcode = null)
        {
            var locaties = _locaties.AsQueryable();
            if (!string.IsNullOrEmpty(gemeente))
                locaties = locaties.Where(l => l.Gemeente.IndexOf(gemeente) >= 0);
            if (!string.IsNullOrEmpty(straatnaam))
                locaties = locaties.Where(l => l.Straatnaam.IndexOf(straatnaam) >= 0);
            if (!string.IsNullOrEmpty(huisnummer))
                locaties = locaties.Where(l => l.Huisnummer.IndexOf(huisnummer) >= 0);
            if (postcode != null)
                locaties = locaties.Where(l => l.Postcode == postcode);
            return locaties.OrderBy(l => l.Gemeente).ToList();
        }

        public Locatie GetById(int id)
        {
            return _locaties.SingleOrDefault(i => i.LocatieId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Locatie locatie)
        {
            _context.Update(locatie);
        }
    }
}
