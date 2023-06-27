using ApiProductos.Models;
using ApiProductos.Services;
using ApiProductos.Services.iServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private readonly IRepository<Venta> _VentaRepository;
        public VentaController (IRepository<Venta> VentaRepository)
        {
            _VentaRepository = VentaRepository;
        }
        [HttpGet]
       
        public async Task <IActionResult> GetAll()
        {
            var ventas = await _VentaRepository.GetAll();
            return Ok(ventas.FirstOrDefault());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _VentaRepository.GetById(id);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Venta))]
        public async Task<IActionResult> Create(Venta ventas)
        {
            Venta result = await _VentaRepository.Create(ventas);
            return new CreatedResult($"https://localhost:7112/api/Venta/{result.Id_Venta}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _VentaRepository.Delete(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venta))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFamilia(Venta venta)
        {
            Venta? result = await _VentaRepository.Update(venta);
            if (result == null)
            return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
