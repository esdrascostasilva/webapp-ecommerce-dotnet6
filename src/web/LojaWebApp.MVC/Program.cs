using LojaWebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration();
builder.Services.RegisterService();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMvcConfiguration(app.Environment);
