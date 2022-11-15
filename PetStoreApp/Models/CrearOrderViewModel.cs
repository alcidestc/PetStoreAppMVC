using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Models
{
    public class CrearOrderViewModel: Order
    {
        [Display(Name = "Estado Mascota")]
        public Status StatusPet { get; set; } = Models.Status.pending;

        [Display(Name = "Mascota")]
        public IEnumerable<SelectListItem> Pets { get; set; }
    }
}
