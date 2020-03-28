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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
