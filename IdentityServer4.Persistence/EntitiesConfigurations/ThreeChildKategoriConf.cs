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
    public class ThreeChildKategoriConf : IEntityTypeConfiguration<ThreeChildKategori>
    {
        public void Configure(EntityTypeBuilder<ThreeChildKategori> builder)
        {
            builder.HasMany(x => x.OneChildKategorilers).WithOne(x => x.ThreeChildKategori).HasForeignKey(x => x.ThreeChildKategoriID).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(x => x.Id);
        }
    }
}
