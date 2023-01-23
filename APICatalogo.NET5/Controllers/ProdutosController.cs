using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace APICatalogo.NET5.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context) 
        {
            _context= context;
        }

        [HttpGet("ListaProdutos")]
        public ActionResult<IEnumerable<Produto>> Getprodutos() 
        {
            try
            {
                return _context.Produtos.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter os produtos no banco de dados");
            }
        }

        [HttpGet("{id}Produtos")]
        public ActionResult<Produto> GetProdutosById(int id) 
        {
            try
            {
                var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
                if(produto == null)
                {
                    return NotFound($"O produto com ID = {id} não foi encontrado");
                }
                return Ok(produto);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter produto no banco de dados");
            }
        }
    }
}
