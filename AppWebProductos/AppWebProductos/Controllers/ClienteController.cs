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
    }
}
