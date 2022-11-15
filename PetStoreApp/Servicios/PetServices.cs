using Newtonsoft.Json;
using PetStore.Modelos;
using PetStoreApp.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PetStoreApp.Servicios
{
    public class PetServices : IPetServices
    {
        private readonly HttpClient client;
        private readonly string _url = $"{Constantes.URL}/pet";
        private readonly IUtilidades _utilidades;
        public PetServices(IUtilidades utilidades)
        {
            client = new HttpClient();
            this._utilidades = utilidades;
        }

        public async Task<IEnumerable<Pet>> FindByStatus(Status status)
        {
            var result = new List<Pet>();
            
            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var response = await client.GetAsync($"{_url}/findByStatus?status={status.ToString()}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Pet>>(responseBody);
                return result;
            }
            result = null;
            return result;
        }

        public async Task Crear(Pet pet)
        {
            pet.Id = await _utilidades.GenerarId();
            var result = new Pet();
            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var response = await client.PostAsync($"{_url}", new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8, _ContentType));

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Pet>(responseBody);
            }
        }

        public async Task Actualizar(Pet pet)
        {
            var result = new Pet();
            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var response = await client.PutAsync($"{_url}", new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8, _ContentType));

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Pet>(responseBody);
            }
        }

        public async Task Borrar(long id)
        {
            var result = new Pet();
            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var response = await client.DeleteAsync($"{_url}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Pet>(responseBody);
            }
        }

        public async Task<Pet> ObtenerPorId(long id)
        {
            var result = new Pet();

            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var url = $"{_url}/{id}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Pet>(responseBody);
                return result;
            }
            result = null;
            return result;
        }

        public async Task<IEnumerable<Category>> ObtenerCategorias()
        {

            var resultado = new List<Category>()
            {
                new Category(){ Id = 1, Name = "Grande"},
                new Category(){ Id = 2, Name = "Mediano"},
                new Category(){ Id = 3, Name = "Pequeño"}
            };

            return resultado;
        }

        public async Task<Category> ObtenerCategoriaPorId(long id)
        {
            var categorias = await ObtenerCategorias();
            return categorias.Where(c=> c.Id == id).FirstOrDefault();
        }

    }
}
