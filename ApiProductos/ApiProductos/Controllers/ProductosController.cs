using ApiProductos.Models;
using ApiProductos.Services;
using ApiProductos.Services.iServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly IRepository<Productos> _ProductosServices;
        public ProductosController (IRepository<Productos> ProductosServices)
        {
            _ProductosServices = ProductosServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _ProductosServices.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ProductosServices.GetById(id);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Productos))]
        public async Task<IActionResult> Create(Productos productos)
        {
            Productos result = await _ProductosServices.Create(productos);
            return new CreatedResult($"https://localhost:7112/api/Productos/{result.Id_Producto}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ProductosServices.Delete(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Productos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFamilia(Productos producto)
        {
            Productos? result = await _ProductosServices.Update(producto);
            if (result == null)
            return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
