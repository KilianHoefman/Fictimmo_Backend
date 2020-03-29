using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

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
            return _huizen.ToList();
        }

        public IEnumerable<Huis> GetBy(Locatie locatie = null, int? price = null, string type = null, ImmoBureau immoBureau = null)
        {
            var huizen = _huizen.AsQueryable();
            if (locatie != null)
                huizen = huizen.Where(h => h.Locatie == locatie);
            if (price != null)
                huizen = huizen.Where(h => h.Price == price);
            if (!string.IsNullOrEmpty(type))
                huizen = huizen.Where(h => h.Type.IndexOf(type) >= 0);
            if (immoBureau != null)
                huizen = huizen.Where(h => h.ImmoBureau == immoBureau);
            return huizen.OrderBy(h => h.Price).ToList();
        }

        public Huis GetById(int id)
        {
            return _huizen.SingleOrDefault(h => h.Id == id);
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
