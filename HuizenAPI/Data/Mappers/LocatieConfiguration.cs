using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HuizenAPI.Models;

namespace HuizenAPI.Data.Mappers
{
    public class LocatieConfiguration : IEntityTypeConfiguration<Locatie>
    {
        public void Configure(EntityTypeBuilder<Locatie> builder)
        {
            builder.ToTable("Locatie");
            builder.HasKey(l => l.LocatieId);            
            builder.Property(l => l.Gemeente).IsRequired().HasMaxLength(50);
            builder.Property(l => l.Straatnaam).IsRequired().HasMaxLength(50);
            builder.Property(l => l.Huisnummer).IsRequired().HasMaxLength(10);
            builder.Property(l => l.Postcode).IsRequired();            
        }
    }
}
