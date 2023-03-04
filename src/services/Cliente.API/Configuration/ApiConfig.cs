using System;
using Cliente.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Cliente.API.Configuration
{
	public static class ApiConfig
	{
		public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ClientesContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddControllers();

			services.AddCors(options =>
			{
				options.AddPolicy("Total",
					builder =>
					builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});
        }

    }
}

