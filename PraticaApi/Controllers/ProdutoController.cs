using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PraticaApi.Classes;
using PraticaApi.Context;


namespace PraticaApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : ControllerBase
    {
       public readonly ProdutoContext _produto;

        public ProdutoController(ProdutoContext produto)
        {
            _produto = produto;
        }

        [HttpPost("criar")]
        public IActionResult Adicionar (Produto produto)
        {
            _produto.Add(produto);
            _produto.SaveChanges();
            return Ok(produto);
        }
        [HttpGet("Buscar")]
        public IActionResult Buscar()
        {
            var Busca = _produto.Produtos.ToList();
            return Ok(Busca);
        }
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int id)
        {
            var BuscarId = _produto.Produtos.Where(p=> p.Id==id);
            if (BuscarId == null)
            {
                return NotFound();
            }
            return Ok(BuscarId);
        }
        [HttpGet("BuscarNome")]
        public IActionResult BuscarPorNome(string nome)
        {
            var BuscarNome = _produto.Produtos.Where(p=>p.Nome.Contains(nome));
            if (BuscarNome == null)
            {
                return NotFound();
            }
            return Ok(BuscarNome);
        }
        [HttpDelete("DeletarPorId")]
        public IActionResult DeletarId(int id)
        {
            var Delete = _produto.Produtos.Find(id);
            if(Delete== null)
                return NotFound();
            _produto.Produtos.Remove(Delete);
            _produto.SaveChanges();
            return Ok(Delete);
        }
        [HttpPut("Alterar")]
        public IActionResult Alterar(int id,Produto produto)
        {
            var Alterar = _produto.Produtos.Find(id);
            if(Alterar== null)
                return NotFound();
            Alterar.Id = id;
            Alterar.Nome = produto.Nome;
            Alterar.Preco = produto.Preco;
            Alterar.Descricao = produto.Descricao;
            _produto.Produtos.Update(Alterar);
            _produto.SaveChanges();
            return Ok();
        }
    }
}
