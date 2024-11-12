using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.API.Extensions;
using Restaurant.API.Filters;
using Restaurant.Application.Behaviors;
using Restaurant.Application.Consumers;
using Restaurant.Application.Validators;
using Restaurant.Infra.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<RestaurantContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddHostedService<PaymentApprovedConsumer>();
builder.Services.AutoMapperConfig();
builder.Services.AddInfrastructure();
builder.Services.SwaggerConfig();
var key = Encoding.ASCII.GetBytes(builder.Configuration["TokenSettings:Secret"]);
builder.Services.AuthConfig(key);
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidationFilter));
    options.Filters.Add(typeof(CustomExceptionFilter));
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCommonOrderCommandValidator>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CreatedByBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UpdatedByBehavior<,>));

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
