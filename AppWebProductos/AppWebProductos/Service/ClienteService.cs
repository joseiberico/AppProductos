using AppWebProductos.Models;
using Newtonsoft.Json;
using System.Text;

namespace AppWebProductos.Service
{
    public class ClienteService
    {
        private static readonly HttpClient _Client = new HttpClient();
        private static string _baseurl;

        public ClienteService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiRest:baseurl").Value;
        }

        public async Task<List<Cliente>> GetAll()
        {
            var response = await _Client.GetAsync(_baseurl + "Cliente");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(content);
            }

            List<Cliente> Clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);
            return Clientes;
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            // Serializar el objeto cliente a JSON
            var jsonCliente = JsonConvert.SerializeObject(cliente);

            // Crear el contenido HTTP con el JSON del cliente
            var httpContent = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            // Realizar la solicitud POST al servidor
            var response = await _Client.PostAsync(_baseurl + "Cliente", httpContent);

            // Leer la respuesta del servidor
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(content);
                return null;
            }

            // Deserializar la respuesta JSON en un objeto Cliente
            var clienteAgregado = JsonConvert.DeserializeObject<Cliente>(content);

            return clienteAgregado;
        }
    }
}
