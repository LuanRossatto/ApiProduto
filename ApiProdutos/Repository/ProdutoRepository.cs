using ApiProdutos.Interfaces;
using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Repository
{
    public class ProdutoRepository : DbContext
    {
        public ProdutoRepository(DbContextOptions<ProdutoRepository> Options) : base(Options)
        {

        }        
        public DbSet<ProdutoModel> Produto { get; set;}

    }
}
