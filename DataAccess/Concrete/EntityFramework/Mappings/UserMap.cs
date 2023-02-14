using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired().HasColumnName("VARBINARY(500)");
            builder.Property(u => u.Description).HasMaxLength(500);
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Picture).IsRequired().HasMaxLength(250);
            builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.Property(u => u.InsertByName).IsRequired(true).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired(true).HasMaxLength(50);
            builder.Property(u => u.InsertDate).IsRequired(true);
            builder.Property(u => u.IsActive).IsRequired(true);
            builder.Property(u => u.IsDeleted).IsRequired();
            builder.Property(u => u.Note).IsRequired(true).HasMaxLength(500);
            builder.ToTable("Users");
            builder.HasData(new User
            {
                Id = 1,
                RoleId = 1,
                FirstName = "Oğuzhan",
                LastName = "Küçükyamaç",
                Username = "okucukyamac",
                Email = "ogushan888@gmail.com",
                IsActive = true,
                IsDeleted = false,
                InsertByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                InsertDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Admin Kullanıcısı",
                Description = "İlk Admin Kullanıcısı",
                PasswordHash= Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500")
            });
        }
    }
}
