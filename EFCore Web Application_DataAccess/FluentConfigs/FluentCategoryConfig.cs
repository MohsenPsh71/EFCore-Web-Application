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
    class FluentCategoryConfig : IEntityTypeConfiguration<Fluent_Category>
    {
        public void Configure(EntityTypeBuilder<Fluent_Category> builder)
        {
            //Category
            builder.HasKey(c => c.Id);
            builder.ToTable("tnl_CategoryFluent");
            builder.Property(c => c.Name)
                .HasColumnName("CategoryName");
        }
    }
}
