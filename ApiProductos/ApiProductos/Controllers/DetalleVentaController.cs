using ApiProductos.Models;
using ApiProductos.Services;
using ApiProductos.Services.iServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentaController : Controller
    {
        private readonly IRepository<Detalle_Venta> _DetalleVentaServices;
        public DetalleVentaController (IRepository<Detalle_Venta> DetalleVentaServices)
        {
            _DetalleVentaServices = DetalleVentaServices;
        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var detalleVentas = await _DetalleVentaServices.GetAll();
            return Ok(detalleVentas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _DetalleVentaServices.GetById(id);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Detalle_Venta))]
        public async Task<IActionResult> CreateDetalleVentas(Detalle_Venta detalleVenta)
        {
            Detalle_Venta result = await _DetalleVentaServices.Create(detalleVenta);
            return new CreatedResult($"https://localhost:7112/api/DetalleVenta/{result.Id_detalle}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _DetalleVentaServices.Delete(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Detalle_Venta))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFamilia(Detalle_Venta detalleVenta)
        {
            Detalle_Venta? result = await _DetalleVentaServices.Update(detalleVenta);
            if (result == null)
            return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
