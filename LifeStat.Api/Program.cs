using LifeStat.Api.Converters;
using LifeStat.Application;
using LifeStat.Infrastructure;

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

var app = builder.Build();

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
