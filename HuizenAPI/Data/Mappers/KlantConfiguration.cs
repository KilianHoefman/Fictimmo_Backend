using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Data.Mappers
{
    public class KlantConfiguration : IEntityTypeConfiguration<Klant>
    {
        public void Configure(EntityTypeBuilder<Klant> builder)
        {
            builder.ToTable("Klant");
            builder.HasKey(k => k.KlantenNummer);
            builder.Property(k => k.KlantenNummer).ValueGeneratedOnAdd();
            builder.Property(k => k.Voornaam).IsRequired().HasMaxLength(15);
            builder.Property(k => k.Achternaam).IsRequired().HasMaxLength(30);
            builder.Property(k => k.GeboorteDatum).IsRequired();
            builder.Property(k => k.Email).IsRequired().HasMaxLength(50);
            builder.Property(k => k.TelefoonNummer).IsRequired().HasMaxLength(50);

            //mapping naar ImmoBureau (unidirectioneel)
            builder.HasOne(k => k.ImmoBureau)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
