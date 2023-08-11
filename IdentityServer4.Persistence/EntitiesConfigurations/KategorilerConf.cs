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
    public class KategorilerConf : IEntityTypeConfiguration<Kategoriler>
    {
        public void Configure(EntityTypeBuilder<Kategoriler> builder)
        {
            builder.HasMany(x=>x.Urunlers).WithOne(x=>x.Kategori).HasForeignKey(x=>x.KategoriID).OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(x => x.Id);
        }
    }
}
