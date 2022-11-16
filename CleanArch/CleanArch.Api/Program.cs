using CleanArch.Api.Configurations;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Ioc;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "University API", Version = "v1" });
});

builder.Services.AddDbContext<UniversityDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDbConnection")));

DependencyContainer.RegisterServices(builder.Services);

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.RegisterAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "University Api V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
