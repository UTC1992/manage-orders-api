using Microsoft.EntityFrameworkCore;
using orders.Domain.Repositories;
using orders.Infrastructure;
using orders.API.Queries;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// mediator to CQRS pattern
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Add context
builder.Services.AddDbContext<DatabaseContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("test"), b => b.MigrationsAssembly("orders.Infrastructure"));
});

// Add Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

