using AutoMapper;
using PetStore.Modelos;

namespace PetStoreApp.Models
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Pet, CrearPetViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
