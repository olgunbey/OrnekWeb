using IdentityServer4.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.EntitiesConfigurations
{
    public class RoleKullanicilarManyToManyConf : IEntityTypeConfiguration<RoleKullanicilarManyToMany>
    {
        public void Configure(EntityTypeBuilder<RoleKullanicilarManyToMany> builder)
        {
            builder.HasOne(x => x.Kullanicilar).WithMany(x => x.RoleKullanicilarManyToManies).HasForeignKey(x => x.KullaniciID);
            builder.HasOne(x => x.Role).WithMany(x => x.RoleKullanicilarManyToManies).HasForeignKey(x => x.RoleID);

            builder.HasKey(key => key.Id);
        }
    }
}
