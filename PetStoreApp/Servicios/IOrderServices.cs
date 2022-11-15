using PetStoreApp.Models;

namespace PetStoreApp.Servicios
{
    public interface IOrderServices
    {
        Task Borrar(long id);
        Task Crear(Order order);
        Task<Order> ObtenerPorId(long id);
    }
}
