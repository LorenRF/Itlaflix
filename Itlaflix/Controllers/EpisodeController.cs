using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.Services;
using Itlaflix.Core.Application.ViewModel.episode;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly IEpisodeService _episodeService;
        private readonly ISeasonService _seasonService;

        public EpisodeController (IEpisodeService episodeService, ISeasonService seasonService)
        {
            _episodeService = episodeService;
            _seasonService = seasonService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _episodeService.GetAllViewModel());
        }

        public async Task<IActionResult> create()
        {
            var viewmodel = new SaveEpisodeViewModel
            {
                seasonList = await _seasonService.GetAllViewModel()
            };
            return View("SaveEpisode", viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> create(SaveEpisodeViewModel ssvm)
        {
            ssvm.seasonList = await _seasonService.GetAllViewModel();

            if (!ModelState.IsValid)
            {
                if(ssvm.SeasonId == null)
                {
                    return View("SaveEpisode", ssvm);
                }
                
            }
            await _episodeService.Add(ssvm);
            return RedirectToRoute(new { controller = "episode", action = "Index" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var viewmodel = await _episodeService.GetByIdSaveViewModel(id);

            viewmodel.seasonList = await _seasonService.GetAllViewModel();
            

            return View("SaveEpisode", viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveEpisodeViewModel ssvm)
        {
            ssvm.seasonList = await _seasonService.GetAllViewModel();

            if (!ModelState.IsValid)
            {
                if(ssvm.SeasonId != null)
                {
                    await _episodeService.Update(ssvm);
                    return RedirectToRoute(new { Controller = "episode", action = "Index" });
                }
                else
                {
                    return View("SaveEpisode", ssvm);
                }
            }

            await _episodeService.Update(ssvm);
            return RedirectToRoute(new { Controller = "episode", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _episodeService.GetByIdSaveViewModel(id));
        }

        public async Task<IActionResult> DeletePost (int id)
        {
            await _episodeService.Delete(id);
            return RedirectToRoute(new { controller = "episode", action = "Index" });
        }

        [HttpGet]
        public async Task<IActionResult> Watch(int id)
        {
            var ssvm = await _episodeService.GetByIdSaveViewModel(id);

            EpisodeViewModel vm = new EpisodeViewModel
            {
                Id = ssvm.Id,
                Name = ssvm.Name,
                Description = ssvm.Description,
                url = ssvm.url,
                imagePath = ssvm.imagePath,
                ReleaseDate = ssvm.ReleaseDate,
                SeasonId = ssvm.SeasonId,
                Season = ssvm.Season
               
            };

            return View("Watch", vm);
        }


    }
}
