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
    public class TwoChildKategoriConf : IEntityTypeConfiguration<TwoChildKategoriler>
    {
        public void Configure(EntityTypeBuilder<TwoChildKategoriler> builder)
        {
            builder.HasMany(x=>x.OneChildKategorilers).WithOne(x=>x.TwoChildKategori).HasForeignKey(x=>x.TwoChildKategoriID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
