using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Application.ViewModel.serie;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IDirectorService _d;
        private readonly IGenderService _g;
        private readonly IProducerService _p;

        public MovieController (IMovieService movieService, IDirectorService d, IGenderService g, IProducerService p)
        {
            _movieService = movieService;
            _d = d;
            _g = g;
            _p = p;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _movieService.GetAllViewModel());
        }

        public async Task<IActionResult> create()
        {
            var saveviewModel = new SaveMovieViewModel
            {
                directorList = await _d.GetAllViewModel(),
                genderList = await _g.GetAllViewModel(),
                producerList = await _p.GetAllViewModel()
            };
            return View("SaveMovie", saveviewModel);
        }

        [HttpPost]
        public async Task<IActionResult> create(SaveMovieViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveMovie", ssvm);
            }
            await _movieService.Add(ssvm);
            return RedirectToRoute(new { controller = "movie", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveMovie", await _movieService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveMovieViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveMovie", ssvm);
            }

            await _movieService.Update(ssvm);
            return RedirectToRoute(new { Controller = "movie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _movieService.GetByIdSaveViewModel(id));
        }

        public async Task<IActionResult> DeletePost (int id)
        {
            await _movieService.Delete(id);
            return RedirectToRoute(new { controller = "movie", action = "Index" });
        }


    }
}
