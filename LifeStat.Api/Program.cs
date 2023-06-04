using LifeStat.Api.Converters;
using LifeStat.Api.Middlewares;
using LifeStat.Application;
using LifeStat.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

builder.Services.AddControllers()
    .AddJsonOptions(op => op.JsonSerializerOptions.Converters.Add(new TimeSpanToJsonStringConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseInfrastructure();

app.MapControllers();

app.Run();
