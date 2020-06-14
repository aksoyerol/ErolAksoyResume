using ErolAksoyResume.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class PortofolioMap : IEntityTypeConfiguration<Portofolio>
    {
        public void Configure(EntityTypeBuilder<Portofolio> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Text).HasColumnType("ntext");
            builder.Property(x => x.ImageUrl).HasMaxLength(100);
        }
    }
}
