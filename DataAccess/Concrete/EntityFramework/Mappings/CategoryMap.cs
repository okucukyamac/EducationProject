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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.InsertByName).IsRequired(true).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired(true).HasMaxLength(50);
            builder.Property(c => c.InsertDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).IsRequired(true).HasMaxLength(500);
            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "C#",
                    Description = "C# Programlama Dili ile ilgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "C# Blog Kategorisi"
                },
                new Category
                {
                    Id = 2,
                    Name = "C++",
                    Description = "C++ Programlama Dili ile ilgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Blog Kategorisi"

                },
                new Category
                {
                    Id = 3,
                    Name = "JavaScript",
                    Description = "JavaScript Programlama Dili ile ilgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript Blog Kategorisi"
                }
                );

        }
    }
}
