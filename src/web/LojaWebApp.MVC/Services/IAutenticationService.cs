using System;
using LojaWebApp.MVC.Models;

namespace LojaWebApp.MVC.Services
{
    public interface IAutenticationService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);

        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}

