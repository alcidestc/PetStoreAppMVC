using Newtonsoft.Json;
using PetStoreApp.Models;
using System.Net.Http.Headers;
using System.Text;

namespace PetStoreApp.Servicios
{
    public class OrderServices: IOrderServices
    {
        private readonly HttpClient client;
        private readonly string _url = $"{Constantes.URL}/store/order";
        private readonly IUtilidades _utilidades;

        public OrderServices(IUtilidades utilidades)
        {
            client = new HttpClient();
            _utilidades = utilidades;
        }

        public async Task Crear(Order order)
        {
            order.Id = await _utilidades.GenerarId();

            var result = new Order();
            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var response = await client.PostAsync($"{_url}", new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, _ContentType));

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Order>(responseBody);
            }
        }

        public async Task<Order> ObtenerPorId(long id)
        {
            var result = new Order();

            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var response = await client.GetAsync($"{_url}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Order>(responseBody);
                return result;
            }
            return result;
        }

        public async Task Borrar(long id)
        {
            var result = new Order();
            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var response = await client.DeleteAsync($"{_url}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Order>(responseBody);
            }
        }
    }
}
