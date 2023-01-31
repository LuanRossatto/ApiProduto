using ApiProdutos.Models;
using ApiProdutos.Repository;

namespace ApiProdutos.Interfaces
{
    public interface IProdutoRepository
    {
        public ProdutoModel Incluir(ProdutoModel obj);
        public bool Excluir(ProdutoModel obj);
        public ProdutoModel Alterar(ProdutoModel obj);
        public ProdutoModel Selecionar(ProdutoModel obj);
        public IEnumerable<ProdutoModel> Retornar();
    }
}
