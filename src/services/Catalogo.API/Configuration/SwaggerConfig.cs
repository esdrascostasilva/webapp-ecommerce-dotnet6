using System;
using Microsoft.OpenApi.Models;

namespace Catalogo.API.Configuration
{
	public static class SwaggerConfig
	{
		public static void AddSwaggerConfiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo()
				{
					Title = "NerdStore Enterprise Catalogo API",
					Description = "Esta API faz parte do curso ASP.Net Core Enterprise Applications.",
					Contact = new OpenApiContact() { Name = "Esdras Costa", Email = "esdras.cts@outlook.com" },
					License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
				});
			});
		}

		public static void UseSwaggerConfiguration(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
			});
		}
	}
}

