using CommonFeature;
using IdentityServer4.API;
using IdentityServer4.Persistence.Context;
using IdentityServer4.Repository.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("Data Source=OLGUNBEY\\OLGUNBEYSQL;Initial Catalog=Ana Proje;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Audience = "apiResource";
    opt.Authority = "https://localhost:7291";
    opt.RequireHttpsMetadata = false;
});


builder.Services.AddAuthorization(opt => opt.AddPolicy("PolicyClient", policy =>
{
    policy.RequireClaim("scope", "api1.client");
}));



builder.Services.AddAuthorization(opt => opt.AddPolicy("Policy1", policy =>
{
    policy.RequireClaim("scope","api1.read");
}));

builder.Services.Scoped();

builder.Services.AddAutoMapper(opt=>opt.AddProfile<MappingProfile>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
