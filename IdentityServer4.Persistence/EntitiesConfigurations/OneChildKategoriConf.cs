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
    public class OneChildKategoriConf : IEntityTypeConfiguration<OneChildKategoriler>
    {
        public void Configure(EntityTypeBuilder<OneChildKategoriler> builder)
        {
            builder.HasMany(x => x.OneChildRelationshipCinsiyets).WithOne(x => x.OneChildKategori).HasForeignKey(x => x.OneChildID);
            builder.HasMany(x => x.Kategorilers).WithOne(x => x.OneChildKategori).HasForeignKey(x => x.OneChildKategoriID);
        }
    }
}
