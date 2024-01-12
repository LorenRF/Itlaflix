// Controlador SerieController
// Este controlador maneja las operaciones relacionadas con la entidad Serie, interactuando con el servicio correspondiente (ISerieService) y otros servicios relacionados.

using Itlaflix.Core.Application.Interfaces.Services;   // Importa las interfaces de servicios
using Itlaflix.Core.Application.Services;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Application.ViewModel.season;
using Itlaflix.Core.Application.ViewModel.serie;
using Itlaflix.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;                        // Importa clases de ASP.NET Core MVC

namespace Itlaflix.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieService _serieService;     // Servicio para operaciones relacionadas con Series
        private readonly IDirectorService _directorService; // Servicio para operaciones relacionadas con Directores
        private readonly IGenderService _genderService;     // Servicio para operaciones relacionadas con Géneros
        private readonly IProducerService _producerService; // Servicio para operaciones relacionadas con Productores
        private readonly ISeasonService _seasonService;

        // Constructor que recibe instancias de los servicios como dependencias
        public SerieController(ISerieService serieService, IDirectorService directorService
            , IGenderService genderService, IProducerService producerService, ISeasonService seasonService)
        {
            _serieService = serieService;
            _directorService = directorService;
            _genderService = genderService;
            _producerService = producerService;
            _seasonService = seasonService;
        }

        // Acción para mostrar la lista de Series
        public async Task<IActionResult> Index()
        {
            // Obtiene la lista de Series y la pasa a la vista
            return View(await _serieService.GetAllViewModel());
        }

        // Acción para mostrar la vista de creación de una nueva Serie
        public async Task<IActionResult> Create()
        {
            // Prepara datos necesarios para la creación, como listas de directores, géneros y productores
            var saveViewModel = new SaveSerieViewModel
            {
                directorList = await _directorService.GetAllViewModel(),
                genderList = await _genderService.GetAllViewModel(),
                producerList = await _producerService.GetAllViewModel()
            };
            // Devuelve la vista "SaveSerie" con el modelo preparado
            return View("SaveSerie", saveViewModel);
        }

        // Acción para procesar el formulario de creación de Serie
        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel ssvm)
        {
            ssvm.directorList = await _directorService.GetAllViewModel();
                ssvm.genderList = await _genderService.GetAllViewModel();
            ssvm.producerList = await _producerService.GetAllViewModel();
           
            // Valida el modelo recibido
            if (!ModelState.IsValid)
            {
                if (ssvm.GendersId.Count > 0)
                {
                    // Llama al servicio para agregar la Serie
            await _serieService.Add(ssvm);
            // Redirige a la acción Index para mostrar la lista actualizada
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
                }   
                // Si el modelo no es válido, vuelve a la vista de creación con el mismo modelo
                    return View("SaveSerie", ssvm);
            }
            // Llama al servicio para agregar la Serie
            await _serieService.Add(ssvm);
            // Redirige a la acción Index para mostrar la lista actualizada
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        // Acción para mostrar la vista de edición de una Serie
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var ssvm = await _serieService.GetByIdSaveViewModel(id);

            ssvm.directorList = await _directorService.GetAllViewModel();
            ssvm.genderList = await _genderService.GetAllViewModel();
            ssvm.producerList = await _producerService.GetAllViewModel();

            // Obtiene el modelo de vista para edición y lo pasa a la vista "SaveSerie"
            return View("SaveSerie", await _serieService.GetByIdSaveViewModel(id));
        }

        // Acción para procesar el formulario de edición de Serie
        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel ssvm)
        {
            ssvm.directorList = await _directorService.GetAllViewModel();
            ssvm.genderList = await _genderService.GetAllViewModel();
            ssvm.producerList = await _producerService.GetAllViewModel();

            // Valida el modelo recibido
            if (!ModelState.IsValid)
            {
                if (ssvm.genderList.Count == 0)
                {
                    // Si el modelo no es válido, vuelve a la vista de edición con el mismo modelo
                    return View("SaveSerie", ssvm);
                }
            }

            // Llama al servicio para actualizar la Serie
            await _serieService.Update(ssvm);
            // Redirige a la acción Index para mostrar la lista actualizada
            return RedirectToRoute(new { Controller = "Serie", Action = "Index" });
        }

        // Acción para mostrar la vista de eliminación de una Serie
        public async Task<IActionResult> Delete(int id)
        {
            // Obtiene el modelo de vista para eliminación y lo pasa a la vista
            return View(await _serieService.GetByIdSaveViewModel(id));
        }

        // Acción para procesar la eliminación de una Serie
        public async Task<IActionResult> DeletePost(int id)
        {
            // Llama al servicio para eliminar la Serie
            await _serieService.Delete(id);
            // Redirige a la acción Index para mostrar la lista actualizada
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Watch(int id)
        {
            var seasonViewModelList = await _seasonService.GetAllViewModel();
            var sortedListDescending = seasonViewModelList.OrderByDescending(s => s.SeasonNumber).ToList();



            return View("Watch", sortedListDescending);
        }
    }
}
