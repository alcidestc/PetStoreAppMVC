using PetStore.Modelos;

namespace PetStoreApp.Models
{
    public class PetListViewModel
    {
        public IEnumerable<Pet> Pets { get; set; } 
        public Status Status { get; set; }
    }
}
