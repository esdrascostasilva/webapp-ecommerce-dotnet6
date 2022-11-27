using Catalogo.API.Configuration;
using Catalogo.API.Data;
using Catalogo.API.Data.Repository;
using Catalogo.API.Models;
using Core.WebAPI.ClassLibrary.Identidade;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddApiConfiguration(configuration);
//JWT
builder.Services.AddAuthConfiguration(configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();
var env = app.Environment;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerConfiguration();

app.UseApiConfiguration(env);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

