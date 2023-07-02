using ApiProductos.Models;
using ApiProductos.Services.iServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly IRepository<Categoria> _CategoriaServices;
        public CategoriaController(IRepository<Categoria> CategoriaServices)
        {
            _CategoriaServices = CategoriaServices;
        }
        [HttpGet]
        public async Task<IActionResult> ListaCategorias()
        {
            var categorias = await _CategoriaServices.GetAll();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var result = await _CategoriaServices.GetById(id);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Categoria))]
        public async Task<IActionResult> CrearCategorias(Categoria categoria)
        {
            Categoria result = await _CategoriaServices.Create(categoria);
            return new CreatedResult($"https://localhost:7112/api/Categoria/{result.Id_Categoria}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var result = await _CategoriaServices.Delete(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categoria))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFamilia(Categoria categoria)
        {
            Categoria? result = await _CategoriaServices.Update(categoria);
            if (result == null)
            return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
