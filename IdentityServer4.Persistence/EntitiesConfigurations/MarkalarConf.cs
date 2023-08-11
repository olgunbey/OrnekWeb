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
    public class MarkalarConf : IEntityTypeConfiguration<Markalar>
    {
        public void Configure(EntityTypeBuilder<Markalar> builder)
        {
            builder.HasMany(x=>x.Urunlers).WithOne(x=>x.Markalar).HasForeignKey(x=>x.MarkalarID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
