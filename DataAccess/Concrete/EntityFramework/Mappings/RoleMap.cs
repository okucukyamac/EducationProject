using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).IsRequired(true).HasMaxLength(70);
            builder.Property(r => r.Description).IsRequired().HasMaxLength(250);
            builder.Property(r => r.InsertByName).IsRequired(true).HasMaxLength(50);
            builder.Property(r => r.ModifiedByName).IsRequired(true).HasMaxLength(50);
            builder.Property(r => r.InsertDate).IsRequired(true);
            builder.Property(r => r.IsActive).IsRequired(true);
            builder.Property(r => r.IsDeleted).IsRequired();
            builder.Property(r => r.Note).IsRequired(true).HasMaxLength(500);
            builder.ToTable("Roles");
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Admin Rolü, Tüm Haklara Sahiptir.",
                IsActive = true,
                IsDeleted = false,
                InsertByName = "InitialCreate",
                InsertDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Admin Rolüdür."
            });
        }
    }
}
