using System;
using System.ComponentModel.DataAnnotations;

namespace Identidade.API.Models
{
    public class UsuarioRegistro
    {
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "{0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "{0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senha nao conferem")]
        public string SenhaConfirmacao { get; set; }
    }

    public class UsuarioLogin
    {
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "{0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "{0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }

    public class UsuarioRespostaLogin
    {
        public string TokenAcesso { get; set; }
        public double ExpiraEm { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }

    public class UsuarioToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }

    public class UsuarioClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}

