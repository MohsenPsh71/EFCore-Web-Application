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
   public class FluentPublisherConfig: IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> builder)
        {
            builder.HasKey(b => b.Publisher_Id);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Location).IsRequired();
        }
    }
}
