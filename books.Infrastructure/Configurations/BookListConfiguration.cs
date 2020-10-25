using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using books.Core.Entities;
namespace books.Infrastructure.Configurations
{
    public class BookListConfiguration : IEntityTypeConfiguration<BookList>
    {
        public void Configure(EntityTypeBuilder<BookList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany<Books>(x => x.Id)
                .WithOne(i => i.BookList)
                .HasForeignKey(x => x.BookId);

        }
    }
}
