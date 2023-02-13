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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).IsRequired().HasMaxLength(2000);
            builder.HasOne<Article>(c=>c.Article).WithMany(a=>a.Comments).HasForeignKey(a=>a.ArticleId);
            builder.Property(c => c.InsertByName).IsRequired(true).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired(true).HasMaxLength(50);
            builder.Property(c => c.InsertDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).IsRequired(true).HasMaxLength(500);
            builder.ToTable("Comments");
        }
    }
}
