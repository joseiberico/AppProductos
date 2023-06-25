using AppWebProductos.Models;
using Newtonsoft.Json;

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
    }
}
