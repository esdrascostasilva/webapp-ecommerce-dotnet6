using System;
using Catalogo.API.Models;
using Core.WebAPI.ClassLibrary.Identidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{

	[Route("api/catalogo/")]
	[ApiController]
	[Authorize]
	public class CatalogoController : Controller
	{
		private readonly IProdutoRepository _produtoRepository;

		public CatalogoController(IProdutoRepository produtoRepository)
        {
			_produtoRepository = produtoRepository;
		}

		[AllowAnonymous]
		[HttpGet("produtos")]
		public async Task<IEnumerable<Produto>> Index()
		{
			return await _produtoRepository.ObterTodos();
		}

		[ClaimsAuthorize("Catalogo","Leitura")]
		[HttpGet("produtos/{id}")]
		public async Task<Produto> ProdutoDetalhe(Guid id)
		{
			return await _produtoRepository.ObterPorId(id);
		}
	}
}

