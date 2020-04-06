using HuizenAPI.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            //_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Locatie Gent1 = new Locatie("Gent", "Vlaanderenstraat", "1A", 9000);
                Locatie Gent2 = new Locatie("Gent", "Overpoortstraat", "6", 9000);
                Locatie Merelbeke = new Locatie("Merelbeke", "Sint-elooistraat", "72", 9820);
                Locatie[] locaties = new Locatie[] { Gent1, Gent2, Merelbeke };
                _dbContext.AddRange(locaties);

                Detail Detail1 = new Detail("Dit is een lange beschrijving", 200, 250, 200, 1400);
                Detail Detail2 = new Detail("Dit is een lange beschrijving v2", 400, 800, 733, 3466);
                Detail Detail3 = new Detail("Dit is een lange beschrijving v3", 600, 1200, 560, 4500);
                Detail[] details = new Detail[] { Detail1, Detail2, Detail3 };
                _dbContext.AddRange(details);

                ImmoBureau Nobels = new ImmoBureau("Immo Nobels");
                ImmoBureau DaVinci = new ImmoBureau("Immo Da Vinci");
                ImmoBureau CD = new ImmoBureau("CD-Vastgoed");
                ImmoBureau[] immoBureaus = new ImmoBureau[] { Nobels, DaVinci, CD };

                Huis Huis1 = new Huis(Gent1, "Dit is een korte beschrijving", 500000, Detail1, "koop", Nobels);
                Huis Huis2 = new Huis(Gent2, "Dit is een korte beschrijving v2", 452000, Detail2, "koop", CD);
                Huis Huis3 = new Huis(Merelbeke, "Dit is een korte beschrijving v3", 5000, Detail3, "huur", DaVinci);
                Huis[] huizen = new Huis[] { Huis1, Huis2, Huis3 };
                _dbContext.AddRange(huizen);

                Nobels.AddHuis(Huis1);
                CD.AddHuis(Huis2);
                DaVinci.AddHuis(Huis3);
                _dbContext.AddRange(immoBureaus);

                Klant klant1 = new Klant("Jan", "Janssens", DateTime.Now, "JanJanssens@huizen.be", "+32412345678", Nobels);
                _dbContext.Klant.Add(klant1);
                await CreateUser(klant1.Email, "P@ssword1");

            }
            _dbContext.SaveChanges();
        }

        private async Task CreateUser(string email, string password)
        {
            var gebruiker = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(gebruiker, password);
        }
    }
}
