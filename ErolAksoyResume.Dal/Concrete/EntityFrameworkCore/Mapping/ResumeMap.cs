using ErolAksoyResume.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class ResumeMap : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.StartedDate).HasColumnName("Started Date");
            builder.Property(x => x.EndedDate).HasColumnName("Ended Date");
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Text).HasColumnType("ntext");
            //builder.Property(x => x.SubCategoryId).IsRequired();
            //builder.HasOne(x => x.SubCategory).WithMany(x => x.Resumes).HasForeignKey(x => x.SubCategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
