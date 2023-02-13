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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a=>a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(a => a.Content).IsRequired(true).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a=>a.Date).IsRequired(true);
            builder.Property(a=>a.SeoAuthor).IsRequired(true).HasMaxLength(50);
            builder.Property(a=>a.SeoDescription).IsRequired(true).HasMaxLength(150);
            builder.Property(a => a.SeoTags).IsRequired(true).HasMaxLength(70);
            builder.Property(a=>a.ViewsCount).IsRequired(true);
            builder.Property(a=>a.CommentCount).IsRequired(true);
            builder.Property(a=>a.Thumbnail).IsRequired(true).HasMaxLength(250);
            builder.Property(a=>a.InsertByName).IsRequired(true).HasMaxLength(50);
            builder.Property(a=>a.ModifiedByName).IsRequired(true).HasMaxLength(50);
            builder.Property(a=>a.InsertDate).IsRequired(true);
            builder.Property(a=>a.IsActive).IsRequired(true);
            builder.Property(a=>a.IsDeleted).IsRequired(true);
            builder.Property(a=>a.Note).IsRequired(true).HasMaxLength(500);
            builder.HasOne<Category>(a => a.Category).WithMany(c=>c.Articles).HasForeignKey(a=>a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(c => c.Articles).HasForeignKey(a => a.UserId);
            builder.ToTable("Articles");
        }
    }
}
