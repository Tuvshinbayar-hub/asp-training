using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Data.Interfaces;
using DesignAPI_DotNet8.Data.Repositories;
using DesignAPI_DotNet8.Services;
using DesignAPI_DotNet8.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Environmental variable loading
DotNetEnv.Env.Load();

builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = DesignAPI_DotNet8.Data.DatabaseConfig.GetConnectionString();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IStyleService, StyleService>();
builder.Services.AddScoped<IStyleRepository, StyleRepository>();

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
