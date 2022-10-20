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
                return true;

            return false;
        }
    }
}

