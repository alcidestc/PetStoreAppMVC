using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStoreApp.Models;
using PetStoreApp.Servicios;

namespace PetStoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPetServices _petServices;
        private readonly IOrderServices _orderServices;

        public OrderController(
            IPetServices petServices,
            IOrderServices orderServices
            )
        {
            this._petServices = petServices;
            this._orderServices = orderServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = new List<OrderViewModel>();

            return View(orders);
        }

        public async Task<IActionResult> Crear()
        {
            var modelo = new CrearOrderViewModel();
            modelo.Pets = await ObtenerPetsServices(modelo.StatusPet);
            return View(modelo);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(CrearOrderViewModel modelo)
        {
            if (!ModelState.IsValid)
            { 
                modelo.Pets = await ObtenerPetsServices(modelo.StatusPet);
            }

            await _orderServices.Crear(modelo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Borrar(long id)
        {
            var order = await _orderServices.ObtenerPorId(id);
            if (order is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarOrder(long id)
        {
            var order = await _orderServices.ObtenerPorId(id);
            if (order is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            await _orderServices.Borrar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerPets([FromBody] Status status)
        {
            var pets = await ObtenerPetsServices(status);
            return Ok(pets);
        }

        private async Task<IEnumerable<SelectListItem>> ObtenerPetsServices(Status status)
        {
            var pets = await _petServices.FindByStatus(status);
            
            if(pets is null)
            {
                RedirectToAction("NoEncontrado", "Home");
            }

            var resultado = pets.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            var opcionPorDefecto = new SelectListItem("Seleccione una categoria", "", true);

            resultado.Insert(0, opcionPorDefecto);

            return resultado;
        }

    }
}
