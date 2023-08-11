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
            builder.HasOne(x => x.Color).WithMany(x => x.Stocks).HasForeignKey(x => x.RenklerID).OnDelete(DeleteBehavior.Cascade);
            builder.HasAlternateKey(x => new { x.RenklerID, x.UrunlerID,x.Id});
            builder.HasOne(x => x.Size).WithMany(x => x.Stocks).HasForeignKey(x => x.SizeID).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
