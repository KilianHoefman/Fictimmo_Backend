using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Data.Mappers
{
    public class HuisConfiguration : IEntityTypeConfiguration<Huis>
    {
        public void Configure(EntityTypeBuilder<Huis> builder)
        {
            builder.ToTable("Huis");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.KorteBeschrijving).IsRequired().HasMaxLength(450);
            builder.Property(h => h.Price).IsRequired();
            builder.Property(h => h.Type).IsRequired().HasMaxLength(20);


            builder
                .HasOne(h => h.ImmoBureau)
                .WithMany();
                
        }
    }
}
