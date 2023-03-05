using Cliente.API.Application.Commands;
using Core.ClassLibrary.Mediator;
using FluentValidation.Results;
using MediatR;

namespace Cliente.API.Configuration
{
	public static class DIConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IMediatorHandler, MediatorHandler>();
			services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
		}
	}
}

