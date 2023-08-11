using IdentityServer4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.EntitiesConfigurations
{
    public class ProductConf : IEntityTypeConfiguration<Urunler>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Urunler> builder)
        {
            builder.HasOne(x => x.Kategori).WithMany(x => x.Urunlers).HasForeignKey(x => x.KategoriID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Stocks).WithOne(x => x.Urunler).HasForeignKey(x => x.UrunlerID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
