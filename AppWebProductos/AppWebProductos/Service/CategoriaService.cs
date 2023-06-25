using AppWebProductos.Models;
using Newtonsoft.Json;

namespace AppWebProductos.Service
{
    public class CategoriaService
    {
        private static readonly HttpClient _Client = new HttpClient();
        private static string _baseurl;

        public CategoriaService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiRest:baseurl").Value;
        }

        public async Task<List<Categoria>> GetAll()
        {
            var response = await _Client.GetAsync(_baseurl + "Categoria");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(content);
            }
            
            List<Categoria> Categorias = JsonConvert.DeserializeObject<List<Categoria>>(content);
            return Categorias;
        }
    }
}
