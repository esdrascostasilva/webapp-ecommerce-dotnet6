using System;
using Core.ClassLibrary.Data;

namespace Catalogo.API.Models
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}

