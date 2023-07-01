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

        public async Task<IActionResult> AgregarCategoria(Categoria categoria)
        {
            var categoriaAgregado = await categoriaService.AddCategoria(categoria);
            if (categoriaAgregado != null)
            {
                return RedirectToAction("Categoria");
            }
            else
            {
                // Error al agregar el categoria, puedes manejarlo de acuerdo a tus necesidades
                ModelState.AddModelError("", "Error al agregar la categoria.");
                return View();
            }
        }

    }
}
