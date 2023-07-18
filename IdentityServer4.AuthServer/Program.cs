using CommonFeature;
using IdentityServer4.AuthServer;
using IdentityServer4.AuthServer.IdentityServerProfile;
using IdentityServer4.Client.HttpClients;
using IdentityServer4.Persistence.Business;
using IdentityServer4.Persistence.Business.UyelerBusiness;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Persistence.Repository;
using IdentityServer4.Persistence.UnitOfWorks;
using IdentityServer4.Persistence.UyelerRepository;
using IdentityServer4.Repository.IBusiness.UyelerIBusiness;
using IdentityServer4.Repository.Interface;
using IdentityServer4.Repository.Mapping;
using IdentityServer4.Repository.IRepository.UyelerIRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<HttpClientKullaniciApi>(opt => opt.BaseAddress = new Uri("https://localhost:7237/api/"));
builder.Services.AddHttpClient<HttpClientRoleApi>(opt => opt.BaseAddress = new Uri("https://localhost:7237/api/"));
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("Data Source=OLGUNBEY\\OLGUNBEYSQL;Initial Catalog=Ana Proje;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.Scoped();

builder.Services.AddIdentityServer().AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddProfileService<ProfileService>()
    .AddResourceOwnerValidator<ServerProfile>()
    .AddDeveloperSigningCredential();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
