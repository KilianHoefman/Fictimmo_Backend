using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HuizenAPI.Data.Repositories
{
    public class DetailRepository : IDetailRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Detail> _details;

        public DetailRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _details = dbContext.Detail;
        }

        public void Add(Detail detail)
        {
            _details.Add(detail);
        }

        public void Delete(Detail detail)
        {
            _details.Remove(detail);
        }

        public IEnumerable<Detail> GetAll()
        {
            return _details.OrderBy(d => d.TotaleOppervlakte).ToList();
        }

        public IEnumerable<Detail> GetBy(int? bewoonbareOppervlakte = null, int? totaleOppervlakte = null, int? epcWaarde = null, int? kadastraalInkomen = null)
        {
            var details = _details.AsQueryable();
            if (bewoonbareOppervlakte != null)
                details = details.Where(d => d.BewoonbareOppervlakte == bewoonbareOppervlakte);
            if (totaleOppervlakte != null)
                details = details.Where(d => d.TotaleOppervlakte == totaleOppervlakte);
            if (epcWaarde != null)
                details = details.Where(d => d.EPCWaarde == epcWaarde);
            if (kadastraalInkomen != null)
                details = details.Where(d => d.KadastraalInkomen == kadastraalInkomen);
            return details.ToList();
        }

        public Detail GetById(int id)
        {
            return _details.SingleOrDefault(d => d.DetailID == id);
        }


        public void Update(Detail detail)
        {
            _context.Update(detail);
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
