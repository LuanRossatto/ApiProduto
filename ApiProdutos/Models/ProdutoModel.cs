namespace ApiProdutos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricacaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }

    }
}
