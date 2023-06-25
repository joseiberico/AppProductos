﻿using ApiProductos.Models;
using ApiProductos.Repository;
using ApiProductos.Repository.iRepository;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IRepository<Usuario> _UsuarioRepository;
        public UsuarioController (IRepository<Usuario> UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _UsuarioRepository.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _UsuarioRepository.GetById(id);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Usuario))]
        public async Task<IActionResult> Create(Usuario usuarios)
        {
            Usuario result = await _UsuarioRepository.Create(usuarios);
            return new CreatedResult($"https://localhost:7112/api/Usuario/{result.Id_Usuario}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _UsuarioRepository.Delete(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFamilia(Usuario usuario)
        {
            Usuario? result = await _UsuarioRepository.Update(usuario);
            if (result == null)
            return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
