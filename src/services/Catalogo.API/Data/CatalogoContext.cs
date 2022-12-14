using Catalogo.API.Models;
using Core.ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.API.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // para evitar que ele crie as outras propriedades q nao foram customizadas to tipo string com o varchar maximo
            // entao, todas as propriedades do tpo string serao definidas com o varchar que eu especificar
            foreach (var item in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string)))) item.SetColumnType("varchar(100)") ;
            

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            // Save changes retorna um int com o numero de linhas afetadas.
           return await base.SaveChangesAsync() > 0;
        }
    }
}

