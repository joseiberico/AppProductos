using AppWebProductos.Models;
using Newtonsoft.Json;

namespace AppWebProductos.Service
{
    public class UsuarioService
    {
        private static readonly HttpClient _Client = new HttpClient();
        private static string _baseurl;

        public UsuarioService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiRest:baseurl").Value;
        }

        public async Task<List<Usuario>> GetAll()
        {
            var response = await _Client.GetAsync(_baseurl + "Usuario");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(content);
            }

            List<Usuario> Usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);
            return Usuarios;
        }
    }

   
}
