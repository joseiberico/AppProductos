using AppWebProductos.Models;
using AppWebProductos.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppWebProductos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService clienteService;
        public ClienteController(ClienteService Cliente)
        {
            clienteService = Cliente;
        }
        public async Task<IActionResult> Cliente()
        {
            var cliente = await clienteService.GetAll();
            return View(cliente);
        }
        public async Task<IActionResult> AgregarCliente(Cliente cliente)
        {
            var clienteAgregado = await clienteService.AddCliente(cliente);
            if (clienteAgregado != null)
            {
                return RedirectToAction("Cliente");
            }
            else
            {
                // Error al agregar el cliente, puedes manejarlo de acuerdo a tus necesidades
                ModelState.AddModelError("", "Error al agregar el cliente.");
                return View();
            }
        }
    }
}
