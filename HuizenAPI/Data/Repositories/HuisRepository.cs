using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HuizenAPI.Data.Repositories
{
    public class HuisRepository : IHuisRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Huis> _huizen;

        public HuisRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _huizen = dbContext.Huis;
        }

        public void Add(Huis huis)
        {
            _huizen.Add(huis);
        }

        public void Delete(Huis huis)
        {
            _huizen.Remove(huis);
        }

        public IEnumerable<Huis> GetAll()
        {
            return _huizen.Include(h => h.Locatie).Include(h => h.Detail).Include(h => h.ImmoBureau).ToList();
        }

        public IEnumerable<Huis> GetBy(int? price = null, string type = null)
        {
            var huizen = _huizen.AsQueryable();
            if (price != null)
                huizen = huizen.Where(h => h.Price == price);
            if (!string.IsNullOrEmpty(type))
                huizen = huizen.Where(h => h.Type.IndexOf(type) >= 0);
            return huizen.OrderBy(h => h.Price).ToList();
        }

        public Huis GetById(int id)
        {
            return _huizen.Include(h => h.ImmoBureau).Include(h => h.Locatie).Include(h => h.Detail).SingleOrDefault(h => h.Id == id);
        }
        public IEnumerable<Huis> GetByImmoBureau(string Naam)
        {
            return _huizen.Include(h => h.ImmoBureau).Where(i => i.ImmoBureau.Naam.Equals(Naam));
        }

        public IEnumerable<Huis> GetByLocatie(int? Postcode, string Gemeente = null)
        {
            var huizen = _huizen.AsQueryable();
            if (Postcode != null)
                return _huizen.Include(h => h.Locatie).Where(l => l.Locatie.Postcode == Postcode);
            if (!string.IsNullOrEmpty(Gemeente))
                return _huizen.Include(h => h.Locatie).Where(l => l.Locatie.Gemeente.Equals(Gemeente));
            return GetAll();
        }

        public IEnumerable<Huis> GetHuurHuizen()
        {
            return GetAll().Where(h => h.Type.Equals("huur")).ToList();
        }

        public IEnumerable<Huis> GetKoopHuizen()
        {
            return GetAll().Where(h => h.Type.Equals("koop")).ToList();
        }

        public IEnumerable<Huis> GetHuizen()
        {
            return GetAll().Where(h => h.Soort.ToLower().Equals("huis")).ToList();
        }

        public IEnumerable<Huis> GetAppartementen()
        {
            return GetAll().Where(h => h.Soort.ToLower().Contains("app")).ToList();
        }

        public IEnumerable<Huis> GetGronden()
        {
            return GetAll().Where(h => h.Soort.ToLower().Contains("grond")).ToList();
        }

        public void Update(Huis huis)
        {
            _context.Update(huis);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
