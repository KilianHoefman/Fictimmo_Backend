using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.Data.Repositories
{
    public class ImmoBureauRepository : IImmoBureauRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<ImmoBureau> _immoBureaus;

        public ImmoBureauRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _immoBureaus = dbContext.ImmoBureau;
        }

        public void Add(ImmoBureau immoBureau)
        {
            _immoBureaus.Add(immoBureau);
        }

        public void Delete(ImmoBureau immoBureau)
        {
            _immoBureaus.Remove(immoBureau);
        }

        public IEnumerable<ImmoBureau> GetAll()
        {
            return _immoBureaus.OrderBy(i => i.Naam).ToList();
        }

        public IEnumerable<ImmoBureau> GetBy(string naam)
        {
            return _immoBureaus.Where(i => i.Naam == naam).ToList();
        }

        public ImmoBureau GetById(int id)
        {
            return _immoBureaus.SingleOrDefault(i => i.ID == id);
        }

        public void Update(ImmoBureau immoBureau)
        {
            _context.Update(immoBureau);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
