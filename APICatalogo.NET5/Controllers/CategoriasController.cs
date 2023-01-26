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
    }
}
