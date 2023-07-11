using CommonFeature;
using IdentityServer4.Client.AuthBusiness;
using IdentityServer4.Client.HttpClients;
using IdentityServer4.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<HttpClientApi>(opt => opt.BaseAddress = new Uri("https://localhost:7237/api/"));
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("Data Source=OLGUNBEY\\OLGUNBEYSQL;Initial Catalog=AnaProje;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
builder.Services.AddHttpClient<HttpClientKullaniciApi>(opt => opt.BaseAddress = new Uri("https://localhost:7237/api/"));
builder.Services.AddHttpClient<ClientCredentials>(opt => opt.BaseAddress = new Uri("https://localhost:7237/api/"));

builder.Services.Scoped();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie("Cookies",
    opt =>
    {
        opt.LoginPath = "/Kullanici/GirisYap";
        
        opt.ExpireTimeSpan = TimeSpan.FromSeconds(20);
    });

builder.Services.AddScoped<IAuthorizationHandler, Authorizations>();
builder.Services.AddAuthorization(opt => {

    opt.AddPolicy("YasakliYer", opt => opt.AddRequirements(new AuthorizationBusiness()));

});
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
app.UseAuthentication();
app.UseAuthorization();


app.MapDefaultControllerRoute();

app.Run();
