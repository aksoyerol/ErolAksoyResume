using ErolAksoyResume.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class SkillMap : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.LevelPercent).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Text).HasColumnType("ntext");

            builder.HasOne(x => x.SubCategory).WithMany(x => x.Skills).HasForeignKey(x => x.SubCategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
