using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HuizenAPI.Data.Mappers
{
    public class ImmoBureauConfiguration : IEntityTypeConfiguration<ImmoBureau>
    {
        public void Configure(EntityTypeBuilder<ImmoBureau> builder)
        {
            builder.ToTable("ImmoBureau");
            builder.HasKey(i => i.ImmoBureauId);
            builder.Property(i => i.Naam).IsRequired().HasMaxLength(100);
        }
    }
}
