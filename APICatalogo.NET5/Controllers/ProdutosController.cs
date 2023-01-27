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
            _context = context;
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

        [HttpGet("{id}Produtos", Name = "ObtenhaProdutos")]
        public ActionResult<Produto> GetProdutosById(int id)
        {
            try
            {
                var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
                if (produto == null)
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

        [HttpPost("AddProdutos")]
        public ActionResult InserirProdutos([FromBody] Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObtenhaProdutos", new { id = produto.ProdutoId }, produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar adicionar um novo produto");
            }
        }

        [HttpPut("{id}Produto")]
        public ActionResult AlterarProduto(int id, [FromBody] Produto produto)
        {
            try
            {
                if(id != produto.ProdutoId)
                {
                    return BadRequest($"Não foi possivel alterar o produto com ID = {id}");
                }
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok($"O Produto com ID = {id} foi alterado com sucesso");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o produto com id = {id}");
            }
        }

        [HttpDelete("{id}Produto")]
        public ActionResult<Produto> Delete(int id)
        {

            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                //var produto = _context.Produtos.Find(id);            //O metodo find vai direto na memória e localiza o produto (mas o id deve ser a chave primaria da tabela).

                if (produto == null)
                {
                    return NotFound($"O produto com ID = {id} não foi encontrado");
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return produto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir o produto com id ={id}");
            }

        }
    }
}
