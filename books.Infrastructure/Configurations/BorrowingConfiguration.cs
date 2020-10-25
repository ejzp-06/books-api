﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using books.Core.Entities;
namespace books.Infrastructure.Configurations
{
    public class BorrowingConfiguration : IEntityTypeConfiguration<Borrowing>
    {
           public void Configure(EntityTypeBuilder<Borrowing> builder)
            {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.BookId).IsRequired().IsConcurrencyToken();

            }
    }

}