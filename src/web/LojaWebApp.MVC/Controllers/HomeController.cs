using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LojaWebApp.MVC.Models;

namespace LojaWebApp.MVC.Controllers;

public class HomeController : MainController
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Route("erro/{id:length(3,3)}")]
    public IActionResult Error(int id)
    {
        var modelErro = new ErrorViewModel();

        if (id == 500)
        {
            modelErro.Titulo = "Ocorreu um erro!";
            modelErro.Mensagem = "Ocorreu um erro! Tente novamete mais tarde ou contate nosso suporte";
            modelErro.ErroCode = id;
        }
        else if (id == 404)
        {
            modelErro.Titulo = "Ops! Pagina nao encontrada";
            modelErro.Mensagem = "A pagina que vc esta procurando nao existe.<br />Em caso de duvida contate nosso suporte";
            modelErro.ErroCode = id;
        }
        else if (id == 403)
        {
            modelErro.Titulo = "Acesso negado.";
            modelErro.Mensagem = "Voce nao tem permissao para executar esta acao.";
            modelErro.ErroCode = id;
        }
        else
        {
            return StatusCode(404);
        }

        return View("Error", modelErro);
    }
}

