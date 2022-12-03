using LojaWebApp.MVC.Extensions;
using LojaWebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace LojaWebApp.MVC.Services
{
    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        //public CatalogoService(HttpClient httpClient, IOptions<AppSettings> settings)
        //{
        //    httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        //    _httpClient = httpClient;
        //}

        public CatalogoService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            //var produtoContent = ObterConteudo(ProdutoViewModel);
            //var response = await _httpClient.PostAsync("https://localhost:7006/api/catalogo/produtos", loginContent);
            //var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");

            var response = await _httpClient.GetAsync($"https://localhost:7006/api/catalogo/produtos/{id}");
            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ProdutoViewModel>(response);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            //var response = await _httpClient.GetAsync("/catalogo/produtos");
            var response = await _httpClient.GetAsync("https://localhost:7006/api/catalogo/produtos");
            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<ProdutoViewModel>>(response);
        }
    }
}

