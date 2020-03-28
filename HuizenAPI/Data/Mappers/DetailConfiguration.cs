using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Data.Mappers
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.ToTable("Detail");
            builder.HasKey(d => d.DetailID);
            builder.Property(d => d.LangeBeschrijving).IsRequired().HasMaxLength(1000);
            builder.Property(d => d.BewoonbareOppervlakte).IsRequired();
            builder.Property(d => d.TotaleOppervlakte).IsRequired();
            builder.Property(d => d.EPCWaarde).IsRequired();
            builder.Property(d => d.KadastraalInkomen).IsRequired();
        }
    }
}
