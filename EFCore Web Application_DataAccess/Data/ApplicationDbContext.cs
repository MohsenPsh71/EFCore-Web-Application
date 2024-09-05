using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreWebApplication_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApplication_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Fluent_BookDetail> FluentBookDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(b => new {b.Author_Id, b.Book_Id});

            #region Book Details

            modelBuilder.Entity<Fluent_BookDetail>().HasKey(b => b.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>()
                .Property(b => b.NumberOfChapters)
                .IsRequired();

            #endregion
        }
    }
}
