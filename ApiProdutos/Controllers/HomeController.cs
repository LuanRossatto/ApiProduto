using ApiProdutos.Models;
using ApiProdutos.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using X.PagedList;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {        
        private readonly ProdutoRepository _context;

        public HomeController(ProdutoRepository context)
        {            
            _context = context;

        }
      

        [HttpPost("Retornar")]
        public async Task<IActionResult> RetornaProduto(int id)
        {
            ProdutoModel obj = new ProdutoModel();
            obj = await _context.Produto.FindAsync(id);
            return Ok(obj);
        }

        [HttpPost("Inserir")]
        public async Task<IActionResult> InserirProduto(ProdutoModel obj)
        {
            if (obj.DataFabricacao >= obj.DataValidade) return BadRequest("Data de fabricação menor igual a Data de Validade");
            await _context.Produto.AddAsync(obj);
            _context.SaveChanges();
            return Ok(obj);
        }

        [HttpGet("Listar")]
        public async Task<IEnumerable<ProdutoModel>> ListaProdutos(int Pagina = 1,DateTime? DataValidade = null, DateTime? DataFabricacao = null,int? CodFornecedor = null)
        {
            IEnumerable<ProdutoModel> list;
            list = await _context.Produto.ToListAsync();
            if (DataValidade != null)
            {
                list = list.Where(x => x.DataValidade == DataValidade).ToList();
            }else if(DataFabricacao != null)
            {
                list = list.Where(x => x.DataFabricacao == DataFabricacao).ToList();
            }else if(CodFornecedor != null)
            {
                list = list.Where(x => x.CodigoFornecedor == CodFornecedor).ToList();
            }
            return list;
        }

        [HttpDelete("Deletar")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            ProdutoModel obj = new ProdutoModel();
            obj.Id = id;
            _context.Produto.Remove(obj);
            _context.SaveChanges();
            return Ok("Produto Excluido com Sucesso!");
        }

        [HttpPost("Alterar")]
        public async Task<IActionResult> AlterarProduto(ProdutoModel obj)
        {
            if (obj.DataFabricacao >= obj.DataValidade) return BadRequest("Data de fabricação menor igual a Data de Validade");
            ProdutoModel Prod = _context.Produto.Find(obj);
            _context.Produto.Entry(Prod).CurrentValues.SetValues(obj);
            _context.SaveChanges();
            return Ok(obj);

        }
    }
}