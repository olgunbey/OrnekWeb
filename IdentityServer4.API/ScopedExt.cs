using AutoMapper;
using IdentityServer4.Persistence.Business;
using IdentityServer4.Persistence.Business.UyelerBusiness;
using IdentityServer4.Persistence.Repository;
using IdentityServer4.Persistence.Repository.UyelerRepository;
using IdentityServer4.Persistence.UnitOfWorks;
using IdentityServer4.Persistence.UyelerRepository;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.Mapping;
using IdentityServer4.Repository.UyelerIRepository;

namespace IdentityServer4.API
{
    public static class ScopedExt
    {
        public static void Scoped(this IServiceCollection services)
        {
            services.AddScoped<UyelerIWriteBusiness, UyelerWriteBusiness>();
            services.AddScoped(typeof(IBusinessWrite<>),typeof(WriteBusiness<>));
            
            services.AddScoped<UyelerIReadBusiness, UyelerReadBusiness>();
            services.AddScoped(typeof(IBusinesRead<>), typeof(ReadBusiness<>));


            services.AddScoped<UyelerIReadRepository, UyelerReadRepository>();
            services.AddScoped<UyelerIWriteRepository, UyelerWriteRepository>();
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUnitOfWorks, UnitOfWork>();
        }
    }
}
