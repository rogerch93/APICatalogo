using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using APICatalogo.Context;
using System.Linq;

namespace APICatalogo.NET5.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("ListaCategorias")]
        public ActionResult<IEnumerable<Categoria>> Getcategorias()
        {
            try
            {
                return _context.Categorias.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter os produtos no banco de dados");
            }
        }

        [HttpGet("{id}Categorias", Name = "ObtenhaCategorias")]
        public ActionResult<Categoria> GetCategoriasById(int id)
        {
            try
            {
                var produto = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);
                if (produto == null)
                {
                    return NotFound($"A categoria com ID = {id} não foi encontrada");
                }
                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter categoria no banco de dados");
            }
        }

        [HttpPost("AddCategorias")]
        public ActionResult InserirCategorias([FromBody] Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObtenhaCategorias", new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar adicionar uma nova categoria");
            }
        }

        [HttpPut("{id}Categoria")]
        public ActionResult AlterarCategoria(int id, [FromBody] Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                {
                    return BadRequest($"Não foi possivel alterar a categoria com ID = {id}");
                }
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok($"A categoria com ID = {id} foi alterada com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar a categoria com id = {id}");
            }
        }

        [HttpDelete("{id}Categoria")]
        public ActionResult<Categoria> Delete(int id)
        {

            try
            {
                var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
                //var produto = _context.Produtos.Find(id);            //O metodo find vai direto na memória e localiza o produto (mas o id deve ser a chave primaria da tabela).

                if (categoria == null)
                {
                    return NotFound($"A Categoria com ID = {id} não foi encontrada");
                }

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

                return categoria;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir a categoria com id ={id}");
            }

        }
    }
}
