using ApiProdutos.Models;
using ApiProdutos.Repository;

namespace ApiProdutos
{
    public class InitializeDb
    {
        public static void Initialize(ProdutoRepository obj)
        {
            obj.Database.EnsureCreated();

            if (obj.Produto.Any())
            {
                return;
            }
        }
    }
}
