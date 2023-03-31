using Microsoft.EntityFrameworkCore;
using orders.Domain.Repositories;
using orders.Infrastructure;
using orders_api.ApplicationServices;
using orders_api.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add context
builder.Services.AddDbContext<DatabaseContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("test"), b => b.MigrationsAssembly("orders.Infrastructure"));
});

// Add Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Add Queries
builder.Services.AddScoped<OrderQueries>();

// Add Services to Api
builder.Services.AddScoped<OrderServices>();

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

