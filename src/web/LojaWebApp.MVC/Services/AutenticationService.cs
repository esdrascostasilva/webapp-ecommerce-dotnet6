using System.Text;
using System.Text.Json;
using LojaWebApp.MVC.Models;
using System.Net.Http;

namespace LojaWebApp.MVC.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly HttpClient _httpClient;

        public AutenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin),
                                                    Encoding.UTF8,
                                                    "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7178/api/identidade/autenticar", loginContent);

            // System.Text.Json nao consegue tratar as letras maiusc/minusc
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(JsonSerializer.Serialize(usuarioRegistro),
                                                    Encoding.UTF8,
                                                    "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7178/api/identidade/nova-conta", registroContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}

