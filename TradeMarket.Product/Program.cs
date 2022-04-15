using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.Core.Infrastructure.InterfacesImplements;
using TradeMarket.Product.sakila;
using Microsoft.Extensions.DependencyInjection;
using Serilog.AspNetCore;
using Serilog;
using Serilog.Events;
using MediatR;
using MediatR.Registration;
using System.Reflection;
using TradeMarket.Product.Commands.GameCommands;
using TradeMarket.Product.ServicesReigster;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
services.AddControllers(d=>d.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes=true).AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddMediatR(typeof(Program).Assembly);

services.AddMediatServices();

services.AddRepositoryServices();
services.AddAutoMapper(typeof(Program));

Log.Logger= new LoggerConfiguration()


             .WriteTo.File("logs/Productlog.txt",
                 rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null, rollOnFileSizeLimit: false
                )
             .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);


services.AddDbContext<iteminfoContext>();

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
