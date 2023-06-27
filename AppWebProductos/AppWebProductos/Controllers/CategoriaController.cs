using AppWebProductos.Models;
using AppWebProductos.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppWebProductos.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService categoriaService;

        public CategoriaController(CategoriaService Categoria)
        {
            categoriaService = Categoria;
        }

        public async Task<IActionResult> Categoria()
        {
            var categorias = await categoriaService.GetAll();
            return View(categorias);
        }

    }
}
