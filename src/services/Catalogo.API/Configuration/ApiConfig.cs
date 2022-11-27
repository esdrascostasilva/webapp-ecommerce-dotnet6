using System;
using Catalogo.API.Data;
using Core.WebAPI.ClassLibrary.Identidade;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.API.Configuration
{
	public static class ApiConfig
	{
		public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<CatalogoContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

			services.AddCors(options =>
			{
				options.AddPolicy("Total",
					builder => builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});
        }

		public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseCors("Total");
			//JWT
			app.UserAuthConfiguration();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
    }
}

