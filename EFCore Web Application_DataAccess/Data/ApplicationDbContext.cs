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
            modelBuilder.Entity<Fluent_Book>().HasKey(b => b.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<Fluent_Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(b => b.Price).IsRequired();
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(b => b.Fluent_BookDetail)
                .WithOne(b => b.fluent_Book)
                .HasForeignKey<Fluent_Book>("BookDetail_Id");
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(b => b.FluentPublisher)
                .WithMany(b => b.FluentBooks)
                .HasForeignKey(b => b.Publisher_Id);


            //Author
            modelBuilder.Entity<Fluent_Author>().HasKey(b => b.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(b => b.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(b => b.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(b => b.FullName);

            //Publisher
            modelBuilder.Entity<Fluent_Publisher>().HasKey(b => b.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().Property(b => b.Location).IsRequired();


            //Category
            modelBuilder.Entity<Fluent_Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Fluent_Category>().ToTable("tnl_CategoryFluent");
            modelBuilder.Entity<Fluent_Category>().Property(c => c.Name)
                .HasColumnName("CategoryName");




            //Ralation Many to Many
            modelBuilder.Entity<Fluent_BookAuthor>()
                .HasKey(ba => new {ba.Author_Id, ba.Book_Id});
            modelBuilder.Entity<Fluent_BookAuthor>()
                .HasOne(b => b.FluentBook)
                .WithMany(b => b.FluentBookAuthors)
                .HasForeignKey(b => b.Book_Id);
            modelBuilder.Entity<Fluent_BookAuthor>()
                .HasOne(b => b.FluentAuthor)
                .WithMany(b => b.FluentBookAuthors)
                .HasForeignKey(b => b.Author_Id);


        }
    }
}
