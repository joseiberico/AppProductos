﻿using ApiProductos.Models;
using ApiProductos.Repository.iRepository;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly IRepository<Categoria> _CategoriaRepository;
        public CategoriaController(IRepository<Categoria> CategoriaRepository)
        {
            _CategoriaRepository = CategoriaRepository;
        }
        [HttpGet]
        public IActionResult ListaCategorias()
        {
            var categorias = _CategoriaRepository.GetAll();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var result = await _CategoriaRepository.GetById(id);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Categoria))]
        public async Task<IActionResult> CrearCategorias(Categoria categoria)
        {
            Categoria result = await _CategoriaRepository.Create(categoria);
            return new CreatedResult($"https://localhost:7112/api/Categoria/{result.Id_Categoria}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var result = await _CategoriaRepository.Delete(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categoria))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFamilia(Categoria categoria)
        {
            Categoria? result = await _CategoriaRepository.Update(categoria);
            if (result == null)
            return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
