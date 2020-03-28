using HuizenAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuizenAPI.Data.Mappers
{
    public class ImmoBureauConfiguration : IEntityTypeConfiguration<ImmoBureau>
    {
        public void Configure(EntityTypeBuilder<ImmoBureau> builder)
        {
            builder.ToTable("ImmoBureau");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.Naam).IsRequired().HasMaxLength(100);

            //mapping naar huis            
            builder.HasMany(i => i.Huizen)
                .WithOne(i => i.ImmoBureau)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
