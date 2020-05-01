using System.Collections.Generic;

namespace HuizenAPI.Models
{
    public interface IImmoBureauRepository
    {
        ImmoBureau GetById(int id);
        IEnumerable<ImmoBureau> GetAll();
        IEnumerable<ImmoBureau> GetBy(string naam);
        void Add(ImmoBureau immoBureau);
        void Delete(ImmoBureau immoBureau);
        void Update(ImmoBureau immoBureau);
        void SaveChanges();
    }
}
