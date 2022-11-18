using System;
using Catalogo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
	[Route("api/catalogo/")]
	public class CatalogoController
	{
		private readonly IProdutoRepository _produtoRepository;

		public CatalogoController(IProdutoRepository produtoRepository)
        {
			_produtoRepository = produtoRepository;
		}

		[HttpGet("produtos")]
		public async Task<IEnumerable<Produto>> Index()
		{
			return await _produtoRepository.ObterTodos();
		}

		[HttpGet("produtos/{id}")]
		public async Task<Produto> ProdutoDetalhe(Guid id)
		{
			return await _produtoRepository.ObterPorId(id);
		}
	}
}

