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

        public async Task<IActionResult> ActualizarCategoria(int id)
        {
            var categoria = await categoriaService.GetCategoriaById(id);
            if (categoria == null)
            {
                // La categoría no existe, puedes manejarlo de acuerdo a tus necesidades
                return RedirectToAction("Categoria");
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarCategoria(Categoria categoria)
        {
            var categoriaActualizada = await categoriaService.UpdateCategoria(categoria);
            if (categoriaActualizada != null)
            {
                return RedirectToAction("Categoria");
            }
            else
            {
                // Error al actualizar la categoría, puedes manejarlo de acuerdo a tus necesidades
                ModelState.AddModelError("", "Error al actualizar la categoría.");
                return View(categoria);
            }
        }

        public async Task<IActionResult> EliminarCategoria(int id)
        {
            var categoria = await categoriaService.GetCategoriaById(id);
            if (categoria == null)
            {
                // La categoría no existe, puedes manejarlo de acuerdo a tus necesidades
                return RedirectToAction("Categoria");
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarEliminarCategoria(int id)
        {
            var categoriaEliminada = await categoriaService.DeleteCategoria(id);
            if (categoriaEliminada)
            {
                return RedirectToAction("Categoria");
            }
            else
            {
                // Error al eliminar la categoría, puedes manejarlo de acuerdo a tus necesidades
                ModelState.AddModelError("", "Error al eliminar la categoría.");
                return RedirectToAction("Categoria");
            }
        }


    }
}
