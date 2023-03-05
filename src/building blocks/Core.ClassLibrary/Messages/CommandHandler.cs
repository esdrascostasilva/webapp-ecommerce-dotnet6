using System;
using FluentValidation.Results;

namespace Core.ClassLibrary.Messages
{
	public abstract class CommandHandler
	{
		protected ValidationResult ValidationResult;

		protected CommandHandler()
		{
			ValidationResult = new ValidationResult();
        }

		protected void AdicionarErro(string mensagem)
		{
			ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
		}
	}
}

