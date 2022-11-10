using System.Text;
using System.Text.Json;
using LojaWebApp.MVC.Models;
using System.Net.Http;

namespace LojaWebApp.MVC.Services
{
    public class AutenticationService : Service, IAutenticationService
    {
        private readonly HttpClient _httpClient;
        
        public AutenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }




        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("https://localhost:7178/api/identidade/autenticar", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }
            
            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }




        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("https://localhost:7178/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}

