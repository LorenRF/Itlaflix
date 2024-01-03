using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.season;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;

        public SeasonController (ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _seasonService.GetAllViewModel());
        }

        public IActionResult create()
        {
            return View("SaveSeason", new SaveSeasonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> create(SaveSeasonViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveSeason", ssvm);
            }
            await _seasonService.Add(ssvm);
            return RedirectToRoute(new { controller = "season", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveSeason", await _seasonService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSeasonViewModel ssvm)
        {
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


    }
}
