using ApiProductos.Credentials;
using ApiProductos.Models;
using ApiProductos.Services;
using ApiProductos.Services.iServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuario<Usuario> _UsuarioRepository;

        public UsuarioController(IUsuario<Usuario> UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _UsuarioRepository.GetAll();
            return Ok(usuarios.FirstOrDefault());
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
        public async Task<IActionResult> Update(Usuario usuario)
        {
            Usuario? result = await _UsuarioRepository.Update(usuario);
            if (result == null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginRequest request)
        //{
        //    var usuario = _UsuarioRepository.IniciarSesion(request.Username, request.Password);

        //    if (usuario == null)
        //    {
        //        return Unauthorized();
        //    }
        //    // Obtener el valor de APIKey desde la configuración
        //    var apiKey = _configuration["APIKey"];

        //    return Ok(new { Token = apiKey });

        //}

    }
}
