using crud_test_dotnet.Core.Domain.Interfaces;
using crud_test_dotnet.Infrastructure.Infrastructure.DBContext;
using crud_test_dotnet.Infrastructure.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using crud_test_dotnet.Core.Application.ServiceExtentions;
using crud_test_dotnet.Infrastructure.Infrastructure.EventStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddApplicationLayer();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEventStore, EventStore>();
builder.Services.AddDbContext<CustomerDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
