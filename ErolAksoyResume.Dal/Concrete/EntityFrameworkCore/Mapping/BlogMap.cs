using ErolAksoyResume.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Blog>

    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Text).HasColumnType("ntext");
            builder.Property(x => x.ImageUrl).HasMaxLength(100);
            builder.Property(x => x.AppUserId).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Blogs).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.SubCategory).WithMany(x => x.Blogs).HasForeignKey(x => x.SubCategoryId);

        }
    }
}
