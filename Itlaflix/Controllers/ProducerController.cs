using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.producer;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducerController (IProducerService producerService)
        {
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _producerService.GetAllViewModel());
        }

        public IActionResult create()
        {
            return View("SaveProducer", new SaveProducerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> create(SaveProducerViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProducer", ssvm);
            }
            await _producerService.Add(ssvm);
            return RedirectToRoute(new { controller = "producer", action = "Index" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveProducer", await _producerService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProducerViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProducer", ssvm);
            }

            await _producerService.Update(ssvm);
            return RedirectToRoute(new { Controller = "producer", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _producerService.GetByIdViewModel(id));
        }

        public async Task<IActionResult> DeletePost (int id)
        {
            await _producerService.Delete(id);
            return RedirectToRoute(new { controller = "producer", action = "Index" });
        }


    }
}
