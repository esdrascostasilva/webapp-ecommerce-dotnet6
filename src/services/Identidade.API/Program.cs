using System.Text;
using Core.WebAPI.ClassLibrary.Identidade;
using Identidade.API.Data;
using Identidade.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

#region Configure builder to Environment
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<StartupBase>();
}
#endregion Configure builder to Environment


#region Configure Services

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddErrorDescriber<IdentityMensagensPortugues>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


#region Config JWT
//var appSettingsSection = configuration.GetSection("AppSettings");
//builder.Services.Configure<AppSettings>(appSettingsSection);

//var appSettings = appSettingsSection.Get<AppSettings>();
//var key = Encoding.ASCII.GetBytes(appSettings.Segredo);

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(bearerOptions =>
//{
//    bearerOptions.RequireHttpsMetadata = true;
//    bearerOptions.SaveToken = true;
//    bearerOptions.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("x")),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = appSettings.ValidoEm,
//        ValidIssuer = appSettings.Emissor
//    };
//});

builder.Services.AddAuthConfiguration(configuration);
#endregion


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NerdStore Enterprise Identity API",
        Description = "Esta API faz parte do curso ASP.NET Core Enterprise Applications.",
        Contact = new OpenApiContact() { Name = "Esdras Costa", Email = "esdras.cts@outlook.com", Url = new Uri("https://www.linkedin.com/in/esdras-costa/") },
        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });
});

var app = builder.Build();

#endregion Configure Services

app.UserAuthConfiguration();

#region Configure Pipelines

app.UseSwagger();
app.UseSwaggerUI(c=>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

#endregion Configure Pipelines