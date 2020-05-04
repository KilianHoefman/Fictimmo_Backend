using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            //builder.Property(k => k.GeboorteDatum).IsRequired();
            builder.Property(k => k.Email).IsRequired().HasMaxLength(50);
        }
    }
}
