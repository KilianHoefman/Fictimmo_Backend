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
            builder.Property(h => h.Details).IsRequired();
            builder.Property(h => h.Type).IsRequired();

            builder.HasOne(h => h.Locatie)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.Details)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.ImmoBureau)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
