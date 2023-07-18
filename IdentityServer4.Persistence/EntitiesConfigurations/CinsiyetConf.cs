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
    public class CinsiyetConf : IEntityTypeConfiguration<Cinsiyet>
    {
        public void Configure(EntityTypeBuilder<Cinsiyet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.OneChildRelationshipCinsiyets).WithOne(x=>x.Cinsiyet).HasForeignKey(x=>x.CinsiyetID);
        }
    }
}
