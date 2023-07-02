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
        private readonly IRepository<Venta> _VentaServices;
        public VentaController (IRepository<Venta> VentaServices)
        {
            _VentaServices = VentaServices;
        }
        [HttpGet]
       
        public async Task <IActionResult> GetAll()
        {
            var ventas = await _VentaServices.GetAll();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _VentaServices.GetById(id);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Venta))]
        public async Task<IActionResult> Create(Venta ventas)
        {
            Venta result = await _VentaServices.Create(ventas);
            return new CreatedResult($"https://localhost:7112/api/Venta/{result.Id_Venta}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _VentaServices.Delete(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venta))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Venta venta)
        {
            Venta? result = await _VentaServices.Update(venta);
            if (result == null)
            return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
