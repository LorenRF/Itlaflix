using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.episode;
using Itlaflix.Core.Application.ViewModel.season;
using Itlaflix.Core.Domain.Entities;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;
        private readonly ISerieService _serieService;
        private readonly IEpisodeService _episodeService;

        public SeasonController (ISeasonService seasonService, ISerieService serieService, IEpisodeService episodeService)
        {
            _seasonService = seasonService;
            _serieService = serieService;
            _episodeService = episodeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _seasonService.GetAllViewModel());
        }

        public async Task<IActionResult> create()
        {
            var viewmodel = new SaveSeasonViewModel
            {
                serieList = await _serieService.GetAllViewModel()
            };
            return View("SaveSeason", viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> create(SaveSeasonViewModel ssvm)
        {

            ssvm.serieList = await _serieService.GetAllViewModel();
            
            if (!ModelState.IsValid)
            {
                if(ssvm.SeasonNumber == null || ssvm.SerieId == null)
                {
                    return View("SaveSeason", ssvm);
                }
                
            }
            await _seasonService.Add(ssvm);
            return RedirectToRoute(new { controller = "season", action = "Index" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var viewmodel = await _seasonService.GetByIdSaveViewModel(id);
                viewmodel.serieList = await _serieService.GetAllViewModel();
            

            viewmodel.serieList = await _serieService.GetAllViewModel();
            
            return View("SaveSeason", viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSeasonViewModel ssvm)
        {
            ssvm.serieList = await _serieService.GetAllViewModel();

            if (!ModelState.IsValid)
            {
                return View("SaveSeason", ssvm);
            }

            await _seasonService.Update(ssvm);
            return RedirectToRoute(new { Controller = "season", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _seasonService.GetByIdSaveViewModel(id));
        }

        public async Task<IActionResult> DeletePost (int id)
        {
            await _seasonService.Delete(id);
            return RedirectToRoute(new { controller = "season", action = "Index" });
        }


        [HttpGet]
        public async Task<IActionResult> SeasonEpisodes(int id)
        {
            var episodeVieModelList = await _seasonService.GetAllEpisodes(id);
            var sortedListDescending = episodeVieModelList.OrderByDescending(e => e.Id).ToList();

            return View("SeasonEpisodes", sortedListDescending);
                
                
        }



    }
}
