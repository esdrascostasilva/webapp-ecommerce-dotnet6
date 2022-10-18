
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LojaWebApp.MVC.Models;
using LojaWebApp.MVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticationService _autenticationService;

        public IdentidadeController(IAutenticationService autenticationService)
        {
            _autenticationService = autenticationService;
        }

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<ActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            // Comunicar com a API de registro
            var resposta = await _autenticationService.Registro(usuarioRegistro);

            //if (false) return View(usuarioRegistro);

            // Realizar login na API
            await RealizarLogin(resposta);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);

            // Comunicar com a API de login
            var resposta = await _autenticationService.Login(usuarioLogin);

            //if (false) return View(usuarioLogin);

            // Realizar login na API
            await RealizarLogin(resposta);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        private async Task RealizarLogin(UsuarioRespostaLogin respostaLogin)
        {
            var token = ObterTokenFormatado(respostaLogin.TokenAcesso);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", respostaLogin.TokenAcesso));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true,
            };
            
            await HttpContext.SignInAsync(  CookieAuthenticationDefaults.AuthenticationScheme,
                                            new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}

