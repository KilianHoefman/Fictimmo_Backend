using HuizenAPI.Data.Mappers;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HuizenAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Locatie> Locatie { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Klant> Klant { get; set; }
        public DbSet<Huis> Huis { get; set; }
        public DbSet<ImmoBureau> ImmoBureau { get; set; }              
        public DbSet<Favorieten> Favorieten { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LocatieConfiguration());
            modelBuilder.ApplyConfiguration(new DetailConfiguration());
            modelBuilder.ApplyConfiguration(new KlantConfiguration());
            modelBuilder.ApplyConfiguration(new HuisConfiguration());
            modelBuilder.ApplyConfiguration(new ImmoBureauConfiguration());
            modelBuilder.ApplyConfiguration(new FavorietenConfiguration());
        }
    }
}
