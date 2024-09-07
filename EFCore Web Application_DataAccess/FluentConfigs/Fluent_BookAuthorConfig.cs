using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreWebApplication_Model.Models;

namespace EFCoreWebApplication_DataAccess.FluentConfigs
{
   public class Fluent_BookAuthorConfig : IEntityTypeConfiguration<Fluent_BookAuthor>
   {
       public void Configure(EntityTypeBuilder<Fluent_BookAuthor> builder)
       {
           //Ralation Many to Many
           builder
               .HasKey(ba => new { ba.Author_Id, ba.Book_Id });
           builder
               .HasOne(b => b.FluentBook)
               .WithMany(b => b.FluentBookAuthors)
               .HasForeignKey(b => b.Book_Id);
           builder
               .HasOne(b => b.FluentAuthor)
               .WithMany(b => b.FluentBookAuthors)
               .HasForeignKey(b => b.Author_Id);
        }
   }
}
