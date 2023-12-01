using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Infra;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.API.Extensions;
using System.Text;
using Restaurant.API.Filters;
using FluentValidation.AspNetCore;
using Restaurant.Application.Validators;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
builder.Services.AutoMapperConfig();
builder.Services.AddInfrastructure();
builder.Services.SwaggerConfig();
var key = Encoding.ASCII.GetBytes(builder.Configuration["TokenSettings:Secret"]);
builder.Services.AuthConfig(key);
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCommonOrderCommandValidator>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.JsonSerializationConfig();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API V1");
});

app.MapControllers();


app.Run();
