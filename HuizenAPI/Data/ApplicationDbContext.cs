using HuizenAPI.Data.Mappers;
using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Locatie> Locatie { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Klant> Klant { get; set; }
        public DbSet<Huis> Huis { get; set; }
        public DbSet<ImmoBureau> ImmoBureau { get; set; }

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
        }
    }
}
