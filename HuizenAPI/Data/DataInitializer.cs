using HuizenAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            //_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Locatie Gent1 = new Locatie("Gent", "Vlaanderenstraat", "1A", 9000);
                _dbContext.Add(Gent1);

                Detail Detail1 = new Detail("Dit is een lange beschrijving", 200, 250, 200, 1400);
                _dbContext.Add(Detail1);

                ImmoBureau ImmoBureau1 = new ImmoBureau("Yolo");
                _dbContext.Add(ImmoBureau1);

                Huis Huis1 = new Huis(Gent1, "Dit is een korte beschrijving", 500000, Detail1, "koop", ImmoBureau1);
                _dbContext.Add(Huis1);
            }
            _dbContext.SaveChanges();
        }
    }
}
