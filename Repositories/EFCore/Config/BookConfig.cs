using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, CategoryId = 1 , Title = "İnsan Ne ile Yaşar", Price = 75 },
                new Book { Id = 2, CategoryId = 2, Title = "İnsan İlişkileri", Price = 90 },
                new Book { Id = 3, CategoryId = 1, Title = "Var mısın?", Price = 102 });
        }
    }
}
