using System;
using LojaWebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebApp.MVC.Controllers
{
    public class MainController : Controller    
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Errors.Mensagens.Any())
            {
                foreach (var mensagem in response.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }
                return true;
            }
                

            return false;
        }
    }
}

