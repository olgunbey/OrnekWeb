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
    public class MarkaOneChildKategoriToManyConf : IEntityTypeConfiguration<MarkaOneChildKategoriToMany>
    {
        public void Configure(EntityTypeBuilder<MarkaOneChildKategoriToMany> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(x => x.Markalar).WithMany(x => x.MarkaOneChildKategoriToManies).HasForeignKey(x => x.MarkaID);
            builder.HasOne(x=>x.Kategoriler).WithMany(x=>x.MarkaOneChildKategoriToManies).HasForeignKey(x=>x.KategoriID);
        }
    }
}
