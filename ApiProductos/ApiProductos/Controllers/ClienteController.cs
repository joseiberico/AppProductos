using ApiProductos.Models;
using ApiProductos.Services;
using ApiProductos.Services.iServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IRepository<Cliente> _ClienteRepository;
        public ClienteController (IRepository<Cliente> ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _ClienteRepository.GetAll();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ClienteRepository.GetById(id);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Cliente))]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            Cliente result = await _ClienteRepository.Create(cliente);
            return new CreatedResult($"https://localhost:7112/api/Cliente/{result.Id_Cliente}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ClienteRepository.Delete(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFamilia(Cliente cliente)
        {
            Cliente? result = await _ClienteRepository.Update(cliente);
            if (result == null)
            return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
