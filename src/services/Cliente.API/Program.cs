using Cliente.API.Configuration;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var configuration = builder.Configuration;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiConfiguration(configuration);
//builder.AddJwtConfiguration(configuration);
//builder.AddSwaggerConfiguration();
builder.Services.AddMediatR(typeof(Program));
//builder.RegisterServices();

var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

