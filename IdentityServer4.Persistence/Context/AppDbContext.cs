using IdentityServer4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleKullanicilarManyToMany> RoleKullanicilarManyToManies { get; set; }
        public DbSet<OneChildKategoriler> OneChildKategorilers { get; set; }
        public DbSet<TwoChildKategoriler> TwoChildKategorilers { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<Cinsiyet> Cinsiyets { get; set; }
        public DbSet<OneChildRelationshipCinsiyet> OneChildRelationshipCinsiyets { get; set; }
        public DbSet<MarkaOneChildKategoriToMany> MarkaOneChildKategoriToManies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
