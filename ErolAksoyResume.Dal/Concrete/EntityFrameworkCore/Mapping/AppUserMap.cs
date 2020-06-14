using ErolAksoyResume.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>

    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(10);
            builder.Property(x => x.LastName).HasMaxLength(15);
            builder.Property(x => x.UserName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15);
            builder.Property(x => x.About).HasMaxLength(1500).HasColumnType("ntext");
            builder.Property(x => x.Status).HasMaxLength(40);
            builder.Property(x => x.Adress).HasMaxLength(200);
            builder.Property(x => x.ProfileImageUrl).HasMaxLength(80);
            builder.Property(x => x.CvLinkUrl).HasMaxLength(80);
            
            builder.Property(x => x.Medium).HasMaxLength(25);
            builder.Property(x => x.Twitter).HasMaxLength(25);
            builder.Property(x => x.Facebook).HasMaxLength(25);
            builder.Property(x => x.Instagram).HasMaxLength(25);
            builder.Property(x => x.LinkedIn).HasMaxLength(25);
            builder.Property(x => x.Github).HasMaxLength(25);




        }
    }
}

