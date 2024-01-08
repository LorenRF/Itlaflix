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
            ssvm.directorList = await _d.GetAllViewModel();
            ssvm.genderList = await _g.GetAllViewModel();
            ssvm.producerList = await _p.GetAllViewModel();
            
            if (!ModelState.IsValid)
            {
                if(ssvm.GendersId.Count > 0)
                {
                    await _movieService.Add(ssvm);
                    return RedirectToRoute(new { controller = "movie", action = "Index" });
                }
                
                return View("SaveMovie", ssvm);
            }
            await _movieService.Add(ssvm);
            return RedirectToRoute(new { controller = "movie", action = "Index" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ssvm = await _movieService.GetByIdSaveViewModel(id);

            ssvm.directorList = await _d.GetAllViewModel();
            ssvm.genderList = await _g.GetAllViewModel();
            ssvm.producerList = await _p.GetAllViewModel();

            return View("SaveMovie", ssvm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveMovieViewModel ssvm)
        {
            ssvm.directorList = await _d.GetAllViewModel();
            ssvm.genderList = await _g.GetAllViewModel();
            ssvm.producerList = await _p.GetAllViewModel();

            if (!ModelState.IsValid)
            {
                if(ssvm.genderList.Count == 0)
                {
                    return View("SaveMovie", ssvm);
                }
                
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

        [HttpGet]
        public async Task<IActionResult> Watch(int id)
        {
            var ssvm = await _movieService.GetByIdSaveViewModel(id);

            MovieViewModel vm = new MovieViewModel
            {
                Id = ssvm.Id,
                Name = ssvm.Name,
                Description = ssvm.Description,
                url = ssvm.url,
                imagePath = ssvm.imagePath,
                year = ssvm.year
            };

            return View("Watch", vm);
        }

    

    }
}
