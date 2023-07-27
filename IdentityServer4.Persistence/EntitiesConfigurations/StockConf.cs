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
    public class StockConf : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasOne(x => x.Urunler).WithMany(x => x.Stocks).HasForeignKey(x => x.UrunlerID);
            builder.HasOne(x => x.Color).WithMany(x => x.Stocks).HasForeignKey(x => x.RenklerID);
            builder.HasAlternateKey(x => new { x.RenklerID, x.UrunlerID,x.Id });
            
        }
    }
}
