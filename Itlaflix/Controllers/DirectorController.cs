using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;

        public DirectorController (IDirectorService directorService)
        {
            _directorService = directorService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _directorService.GetAllViewModel());
        }

        public IActionResult create()
        {
            return View("SaveDirector", new SaveDirectorViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> create(SaveDirectorViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveDirector", ssvm);
            }
            await _directorService.Add(ssvm);
            return RedirectToRoute(new { controller = "director", action = "Index" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveDirector", await _directorService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveDirectorViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveDirector", ssvm);
            }

            await _directorService.Update(ssvm);
            return RedirectToRoute(new { Controller = "director", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _directorService.GetByIdViewModel(id));
        }

        public async Task<IActionResult> DeletePost (int id)
        {
            await _directorService.Delete(id);
            return RedirectToRoute(new { controller = "director", action = "Index" });
        }


    }
}
