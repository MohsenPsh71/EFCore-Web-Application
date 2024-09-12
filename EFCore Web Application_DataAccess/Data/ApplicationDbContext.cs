using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreWebApplication_Model.Models;
using Microsoft.EntityFrameworkCore;
using EFCoreWebApplication_DataAccess.FluentConfigs;

namespace EFCoreWebApplication_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<BookDetailsFromView> BookDetailsFromViews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Fluent_BookDetail> FluentBookDetails { get; set; }
        public DbSet<Fluent_Book> FluentBooks { get; set; }
        public DbSet<Fluent_Author> FluentAuthors { get; set; }
        public DbSet<Fluent_Publisher> FluentPublishers { get; set; }
        public DbSet<Fluent_Category> FluentCategories { get; set; }

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

            //Book 
          

            //Author
            modelBuilder.Entity<Fluent_Author>().HasKey(b => b.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(b => b.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(b => b.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(b => b.FullName);



            modelBuilder.ApplyConfiguration(new Fluent_BookConfig());
            modelBuilder.ApplyConfiguration(new FluentCategoryConfig());
            modelBuilder.ApplyConfiguration(new Fluent_BookAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());


            modelBuilder.Entity<BookDetailsFromView>().HasNoKey().ToView("GetOnlyBookDetails");






        }
    }
}
