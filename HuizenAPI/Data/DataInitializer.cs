using HuizenAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

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
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Locatie Gent1 = new Locatie("Gent", "Vlaanderenstraat", "1A", 9000);
                Locatie Gent2 = new Locatie("Gent", "Overpoortstraat", "6", 9000);
                Locatie Merelbeke = new Locatie("Merelbeke", "Sint-elooistraat", "72", 9820);
                Locatie Lokeren = new Locatie("Lokeren", "Nijsstraat", "69", 9160);
                Locatie Nieuwpoort = new Locatie("Nieuwpoort", "Vlaanderenstraat", "4", 8620);
                Locatie Waasmunster = new Locatie("Waasmunster", "Muizenberg", "12", 9250);
                Locatie Wondelgem = new Locatie("Wondelgem", "Vierweegsestraat", "6", 9032);
                Locatie[] locaties = new Locatie[] { Gent1, Gent2, Merelbeke, Lokeren, Nieuwpoort, Waasmunster, Wondelgem };
                _dbContext.Locatie.AddRange(locaties);
                Console.WriteLine("Locaties toegevoegd");

                Detail Detail1 = new Detail("Dit is een lange beschrijving", 200, 250, 200, 1400);
                Detail Detail2 = new Detail("Dit is een lange beschrijving v2", 400, 800, 733, 3466);
                Detail Detail3 = new Detail("Dit is een lange beschrijving v3", 600, 1200, 560, 4500);
                Detail Detail4 = new Detail("Dit is een lange beschrijving v4", 220, 650, 420, 950);
                Detail Detail5 = new Detail("Dit is een lange beschrijving v5", 260, 350, 530, 1200);
                Detail Detail6 = new Detail("Dit is een lange beschrijving v6", 800, 5000, 330, 1560);
                Detail Detail7 = new Detail("Dit is een lange beschrijving v7", 650, 2000, 500, 1250);
                Detail Detail8 = new Detail("Uniek gelegen bouwgrond", 540, 1800, 0, 0);
                Detail[] details = new Detail[] { Detail1, Detail2, Detail3, Detail4, Detail5, Detail6, Detail7, Detail8 };
                _dbContext.Detail.AddRange(details);
                Console.WriteLine("Details toegevoegd");

                ImmoBureau Nobels = new ImmoBureau("Immo Nobels");
                ImmoBureau DaVinci = new ImmoBureau("Immo Da Vinci");
                ImmoBureau CD = new ImmoBureau("CD-Vastgoed");
                ImmoBureau[] immoBureaus = new ImmoBureau[] { Nobels, DaVinci, CD };
                _dbContext.AddRange(immoBureaus);

                Huis Huis1 = new Huis(Gent1, "Dit is een korte beschrijving", 500000, Detail1, "koop", "huis", Nobels);
                Huis Huis2 = new Huis(Gent2, "Dit is een korte beschrijving v2", 452000, Detail2, "koop", "appartement", CD);
                Huis Huis3 = new Huis(Merelbeke, "Dit is een korte beschrijving v3", 4500, Detail3, "huur", "huis", DaVinci);
                Huis Huis4 = new Huis(Lokeren, "Dit is een korte beschrijving v4", 419000, Detail4, "koop", "huis", Nobels);
                Huis Huis5 = new Huis(Nieuwpoort, "Dit is een korte beschrijving v5", 2000, Detail5, "huur", "appartement", DaVinci);
                Huis Huis6 = new Huis(Waasmunster, "Dit is een korte beschrijving v6", 1000000, Detail6, "koop", "huis", Nobels);
                Huis Huis7 = new Huis(Wondelgem, "Dit is een korte beschrijving v7", 820000, Detail7, "koop", "huis", CD);
                Huis Huis8 = new Huis(Merelbeke, "Bouwgrond", 345000, Detail8, "koop", "grond", CD);
                Huis[] huizen = new Huis[] { Huis1, Huis2, Huis3, Huis4, Huis5, Huis6, Huis7, Huis8 };
                _dbContext.Huis.AddRange(huizen);
                Console.WriteLine("Huizen toegevoegd");

                Console.WriteLine("ImmoBureaus toegevoegd");

                Klant klant1 = new Klant("Jan", "Janssens", "admin@huizen.be");

                _dbContext.Klant.AddRange(klant1);

                Console.WriteLine("klant toegevoegd");

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
