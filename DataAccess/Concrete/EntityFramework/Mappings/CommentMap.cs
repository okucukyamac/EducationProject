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
            builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).HasForeignKey(a => a.ArticleId);
            builder.Property(c => c.InsertByName).IsRequired(true).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired(true).HasMaxLength(50);
            builder.Property(c => c.InsertDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).IsRequired(true).HasMaxLength(500);
            builder.ToTable("Comments");

            builder.HasData(
                new Comment
                {
                    Id = 1,
                    ArticleId = 1,
                    Text = @"Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz.Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır.Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock,
                    bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır.Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir.Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur.Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "C# Makale yorumu"
                },
                new Comment
                {
                    Id = 2,
                    ArticleId = 3,
                    Text = @"Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz.Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır.Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock,
                    bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır.Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir.Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur.Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Makale yorumu"
                },
                new Comment
                {
                    Id = 3,
                    ArticleId = 3,
                    Text = @"Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz.Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır.Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock,
                    bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır.Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir.Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur.Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "Javascript Makale yorumu"
                }
                );
        }
    }
}
