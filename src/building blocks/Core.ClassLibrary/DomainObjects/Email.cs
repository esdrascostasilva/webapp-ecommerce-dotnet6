using System.Text.RegularExpressions;

namespace Core.ClassLibrary.DomainObjects
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public const int EnderecoMinLength = 5;

        public string EnderecoEmail { get; private set; }

        // Construtor do EntityFramework
        public Email() { }

        public Email(string enderecoEmail)
        {
            if (!Validar(enderecoEmail))
                throw new DomainException("E-mail inválido");

            EnderecoEmail = enderecoEmail;
        }

        public static bool Validar(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}

