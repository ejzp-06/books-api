using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using books.Infrastructure.Configurations;
//using books.Core.Entities;
namespace books.Infrastructure
{

    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions options) :
            base(options)
        {
        }

    }
    /***
       public DbSet<Book> Books { get; set; }
       public DbSet<Author> Author{get; set;}
       public DbSet<BookList> BookList{get; set;}
       public DbSet<Borrowing> Borrowing{get; set;}
       public DbSet<Return> Return{get; set;}
     */   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration()); 
            modelBuilder.ApplyConfiguration(new BookListConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowingConfiguration());
            modelBuilder.ApplyConfiguration(new ReturnConfiguration());
           
         }
    
}
