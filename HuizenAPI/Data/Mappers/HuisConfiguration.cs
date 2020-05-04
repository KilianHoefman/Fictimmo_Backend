using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
