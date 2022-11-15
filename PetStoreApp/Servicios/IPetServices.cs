using PetStore.Modelos;
using PetStoreApp.Models;

namespace PetStoreApp.Servicios
{
    public interface IPetServices
    {
        Task Actualizar(Pet pet);
        Task Borrar(long id);
        Task Crear(Pet pet);
        Task<IEnumerable<Pet>> FindByStatus(Status status);
        Task<Category> ObtenerCategoriaPorId(long id);
        Task<IEnumerable<Category>> ObtenerCategorias();
        Task<Pet> ObtenerPorId(long id);
    }
}
