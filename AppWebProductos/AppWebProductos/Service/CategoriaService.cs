using AppWebProductos.Models;
using Newtonsoft.Json;
using System.Text;

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

            List<Categoria> categorias = JsonConvert.DeserializeObject<List<Categoria>>(content);
            return categorias;
        }

        public async Task<Categoria> GetCategoriaById(int categoriaId)
        {
            var response = await _Client.GetAsync(_baseurl + "Categoria/" + categoriaId);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(content);
                return null;
            }

            var categoria = JsonConvert.DeserializeObject<Categoria>(content);
            return categoria;
        }

        public async Task<Categoria> AddCategoria(Categoria categoria)
        {
            // Serializar el objeto cliente a JSON
            var jsonCategoria = JsonConvert.SerializeObject(categoria);

            // Crear el contenido HTTP con el JSON del cliente
            var httpContent = new StringContent(jsonCategoria, Encoding.UTF8, "application/json");

            // Realizar la solicitud POST al servidor
            var response = await _Client.PostAsync(_baseurl + "Categoria", httpContent);

            // Leer la respuesta del servidor
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(content);
                return null;
            }

            // Deserializar la respuesta JSON en un objeto Categoria
            var categoriaAgregado = JsonConvert.DeserializeObject<Categoria>(content);

            return categoriaAgregado;
        }

        public async Task<Categoria> UpdateCategoria(Categoria categoria)
        {
            // Serializar el objeto categoria a JSON
            var jsonCategoria = JsonConvert.SerializeObject(categoria);

            // Crear el contenido HTTP con el JSON de la categoria
            var httpContent = new StringContent(jsonCategoria, Encoding.UTF8, "application/json");

            // Realizar la solicitud PUT al servidor
            var response = await _Client.PutAsync(_baseurl + "Categoria", httpContent);

            // Leer la respuesta del servidor
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(content);
                return null;
            }

            // Deserializar la respuesta JSON en un objeto Categoria
            var categoriaActualizada = JsonConvert.DeserializeObject<Categoria>(content);

            return categoriaActualizada;
        }

        public async Task<bool> DeleteCategoria(int categoriaId)
        {
            // Realizar la solicitud DELETE al servidor
            var response = await _Client.DeleteAsync(_baseurl + "Categoria/" + categoriaId);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return false;
            }

            return true;
        }


    }
}
