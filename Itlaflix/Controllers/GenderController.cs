using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.gender;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;

        public GenderController (IGenderService genderService)
        {
            _genderService = genderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _genderService.GetAllViewModel());
        }

        public IActionResult create()
        {
            return View("SaveGender", new SaveGenderViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> create(SaveGenderViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGender", ssvm);
            }
            await _genderService.Add(ssvm);
            return RedirectToRoute(new { controller = "gender", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveGender", await _genderService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGenderViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGender", ssvm);
            }

            await _genderService.Update(ssvm);
            return RedirectToRoute(new { Controller = "gender", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _genderService.GetByIdSaveViewModel(id));
        }

        public async Task<IActionResult> DeletePost (int id)
        {
            await _genderService.Delete(id);
            return RedirectToRoute(new { controller = "gender", action = "Index" });
        }


    }
}
