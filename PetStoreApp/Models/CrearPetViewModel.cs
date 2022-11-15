using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Modelos;
using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Models
{
    public class CrearPetViewModel: Pet
    {
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Categoria")]
        public long CategoriaId { get; set; }
    }
}
