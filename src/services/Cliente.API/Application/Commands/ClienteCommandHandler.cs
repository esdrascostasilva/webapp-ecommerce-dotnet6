using System;
using Core.ClassLibrary.Messages;
using FluentValidation.Results;
using MediatR;

namespace Cliente.API.Application.Commands
{
	public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
	{
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
			if (!message.EhValido())
                return message.ValidationResult;

			var cliente = new Models.Cliente(message.Id, message.Nome, message.Email, message.Cpf);

			// validacoes de nefocio
			//Persistir no banco

			if (true) // se ja existir um cliente com o Cpf informado
			{
				AdicionarErro("CPF informado já está em uso");
				return ValidationResult; // retornando o ValidationResult pq o erro ja vai estar la dentro
			}

			return message.ValidationResult;
        }

        public void Manipular(RegistrarClienteCommand message)
		{
			// validar comando

			// persistir na base
		}
	}
}

