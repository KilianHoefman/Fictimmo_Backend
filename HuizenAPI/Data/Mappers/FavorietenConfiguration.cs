using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HuizenAPI.Data.Mappers
{
    public class FavorietenConfiguration : IEntityTypeConfiguration<Favorieten>
    {
        public void Configure(EntityTypeBuilder<Favorieten> builder)
        {
            builder.ToTable("Favorieten");
        }
    }
}
