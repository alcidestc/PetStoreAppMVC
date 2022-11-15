using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Modelos;
using PetStoreApp.Models;
using PetStoreApp.Servicios;

namespace PetStore.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetServices _petServices;
        private readonly IMapper _mapper;

        public PetController(
            IPetServices petServices,
            IMapper mapper
            )
        {
            this._petServices = petServices;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(Status status = Status.available)
        {
            var modelo = new PetListViewModel();
            modelo.Pets = await _petServices.FindByStatus(status);
            if(modelo.Pets == null)
            {
                RedirectToAction("NoEncontrado", "Home");
            }
            modelo.Status = status;
            return View(modelo);
        }

        public async Task<IActionResult> Crear()
        {
            var modelo = new CrearPetViewModel();
            modelo.Categories = await ObtenerCategorias();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CrearPetViewModel pet)
        {
            if (!ModelState.IsValid)
            {
                pet.Categories = await ObtenerCategorias();
                return View(pet);
            }

            pet.Category = await _petServices.ObtenerCategoriaPorId(pet.CategoriaId);

            await _petServices.Crear(pet);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Editar(long id)
        {

            var pet = await _petServices.ObtenerPorId(id);
            if (pet is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            var modelo = _mapper.Map<CrearPetViewModel>(pet);
            modelo.Categories = await ObtenerCategorias();
            modelo.CategoriaId = pet.Category.Id;

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> EditarPet(CrearPetViewModel pet)
        {
            if (!ModelState.IsValid)
            {
                pet.Categories = await ObtenerCategorias();
                return View(pet);
            }

            pet.Category = await _petServices.ObtenerCategoriaPorId(pet.CategoriaId);

            await _petServices.Actualizar(pet);

            return RedirectToAction("Index"); ;
        }

        public async Task<IActionResult> Borrar(long id)
        {
            var pet = await _petServices.ObtenerPorId(id);
            if(pet is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

           return View(pet);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarPet(long id)
        {
            var pet = await _petServices.ObtenerPorId(id);
            if (pet is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            await _petServices.Borrar(id);
            return RedirectToAction("Index");
        }



        private async Task<IEnumerable<SelectListItem>> ObtenerCategorias()
        {
            var categoriasServices = await _petServices.ObtenerCategorias();
            var categorias = categoriasServices.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            var opcionPorDefecto = new SelectListItem("Seleccione una categoria", "", true);

            categorias.Insert(0, opcionPorDefecto);
            return categorias;
        }

    }
}
