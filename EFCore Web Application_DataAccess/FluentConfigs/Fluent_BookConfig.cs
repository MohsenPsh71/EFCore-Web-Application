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
    class Fluent_BookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> builder)
        {
            builder.HasKey(b => b.Book_Id);
            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder
                .HasOne(b => b.Fluent_BookDetail)
                .WithOne(b => b.fluent_Book)
                .HasForeignKey<Fluent_Book>("BookDetail_Id");
            builder
                .HasOne(b => b.FluentPublisher)
                .WithMany(b => b.FluentBooks)
                .HasForeignKey(b => b.Publisher_Id);
        }
    }
}
