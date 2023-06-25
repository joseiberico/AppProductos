using AppWebProductos.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppWebProductos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuario) 
        {
            usuarioService = usuario;
        }
        public async Task<IActionResult>Usuario()
        {
            var usuario = await usuarioService.GetAll();
            return View(usuario);
        }
    }
}
