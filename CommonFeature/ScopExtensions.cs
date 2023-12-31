﻿using IdentityServer4.Domain.Entities;
using IdentityServer4.Persistence.Business;
using IdentityServer4.Persistence.Business.KategoriBusiness;
using IdentityServer4.Persistence.Business.RoleBusiness;
using IdentityServer4.Persistence.Business.UrunlerBusiness;
using IdentityServer4.Persistence.Business.UyelerBusiness;
using IdentityServer4.Persistence.Repository;
using IdentityServer4.Persistence.Repository.KategoriRepository;
using IdentityServer4.Persistence.Repository.RolesRepository;
using IdentityServer4.Persistence.Repository.UrunlerRepository;
using IdentityServer4.Persistence.Repository.UyelerRepository;
using IdentityServer4.Persistence.UnitOfWorks;
using IdentityServer4.Persistence.UyelerRepository;
using IdentityServer4.Repository.IBusiness.KategoriIBusiness;
using IdentityServer4.Repository.IBusiness.RoleIBusiness;
using IdentityServer4.Repository.IBusiness.UrunlerIBusiness;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.IRepository.IUrunlerRepository;
using IdentityServer4.Repository.IRepository.KategoriIRepository;
using IdentityServer4.Repository.IRepository.RolesIRepository;
using IdentityServer4.Repository.IRepository.UyelerIRepository;
using IdentityServer4.Repository.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFeature
{
    public static class ScopExtensions
    {
        public static void Scoped(this IServiceCollection services)
        {
            services.AddScoped<UyelerIWriteBusiness, UyelerWriteBusiness>();
            services.AddScoped(typeof(IBusinessWrite<>), typeof(WriteBusiness<>));

            services.AddScoped<UyelerIReadBusiness, UyelerReadBusiness>();
            services.AddScoped(typeof(IBusinesRead<>), typeof(ReadBusiness<>));

            services.AddScoped<UyelerIReadRepository, UyelerReadRepository>();
            services.AddScoped<UyelerIWriteRepository, UyelerWriteRepository>();
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            //services.AddScoped<IWriteRepository<Role>, WriteRepository<Role>>();
            //services.AddScoped<IReadRepository<Role>, ReadRepository<Role>>();

            services.AddScoped<RoleIReadBusiness, RoleReadBusiness>();
            services.AddScoped<RoleIWriteBusiness, RoleWriteBusiness>();

            services.AddScoped<RolesIReadRepository,RolesReadRepository>();
            services.AddScoped<RolesIWriteRepository,RolesWriteRepository>();

            services.AddScoped<KategoriIReadBusiness, KategoriReadBusiness>();
            services.AddScoped<KategoriIWriteBusiness, KategoriWriteBusiness>();

            services.AddScoped<KategoriIReadRepository, KategoriReadRepository>();
            services.AddScoped<KategoriIWriteRepository, KategoriWriteRepository>();

            services.AddScoped<UrunlerIReadBusiness, UrunlerReadBusiness>();
            services.AddScoped<UrunlerIWriteBusiness, UrunlerWriteBusiness>();

            services.AddScoped<UrunlerIReadRepository,UrunlerReadRepository>();
            services.AddScoped<UrunlerIWriteRepository,UrunlerWriteRepository>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUnitOfWorks, UnitOfWork>();
        }
    }
}
