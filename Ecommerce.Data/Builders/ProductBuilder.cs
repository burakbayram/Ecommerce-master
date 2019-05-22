using Ecommerce.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Builders
{
    public class ProductBuilder
    {
        public ProductBuilder(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
        }
    }
}
