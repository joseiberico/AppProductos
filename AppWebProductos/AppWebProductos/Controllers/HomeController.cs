using AppWebProductos.Models;
using AppWebProductos.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppWebProductos.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoriaService categoriaService;

        public HomeController(CategoriaService Categoria)
        {
            categoriaService = Categoria;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await categoriaService.GetAll();
            return View(categorias);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}