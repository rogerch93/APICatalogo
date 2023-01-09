using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace APICatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetProdutoById(int id) 
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
            if(produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
    }
}
