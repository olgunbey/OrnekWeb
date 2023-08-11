using IdentityServer4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.EntitiesConfigurations
{
    public class ProductDetailConf : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithOne(x => x.ProductDetail).HasForeignKey<ProductDetail>(x => x.UrunlerID);
            builder.Property(x => x.Evaluation).HasDefaultValue(0);
        }
    }
}
