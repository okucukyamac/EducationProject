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

            builder.HasData(
                new Article
                {
                    Id = 1,
                    CategoryId= 1,
                    Title="C# 9.0 ve .NET5 yenilikleri",
                    Content= "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C# 9.0 ve .NET5 yenilikleri",
                    SeoTags = "C#, C# 9, .NET5, .NET Framework, .NET Core",
                    SeoAuthor = "Oğuzhan Küçükyamaç",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "C# 9.0 ve .NET5 yenilikleri",
                    UserId= 1
                },
                new Article
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "C++ 11 yenilikleri",
                    Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C++ 11 yenilikleri",
                    SeoTags = "C++ 11 yenilikleri",
                    SeoAuthor = "Oğuzhan Küçükyamaç",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "C++ 11 yenilikleri",
                    UserId = 1
                },
                new Article
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "Javascript ES2020 yenilikleri",
                    Content = "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "Javascript ES2020 yenilikleri",
                    SeoTags = "Javascript ES2020 yenilikleri",
                    SeoAuthor = "Oğuzhan Küçükyamaç",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    InsertByName = "InitialCreate",
                    ModifiedByName = "InitialCreate",
                    InsertDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Note = "Javascript ES2020 yenilikleri",
                    UserId = 1
                }
                );
        }
    }
}
