using LojaWebApp.MVC.Configuration;


var builder = WebApplication.CreateBuilder(args);

//var app = builder.Build();

//var builder2 = new ConfigurationBuilder()
//                .SetBasePath(app.Environment.ContentRootPath)
//                .AddJsonFile("appsettings.json", true, true)
//                .AddJsonFile($"appsettings.{app.Environment.EnvironmentName}.json", true, true)
//                .AddEnvironmentVariables();


// Add services to the container.

builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterService();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMvcConfiguration(app.Environment);
