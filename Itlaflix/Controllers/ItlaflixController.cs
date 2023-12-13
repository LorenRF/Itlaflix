using Itlaflix.Infrastructure.Persistence.Services;
using Itlaflix.Core.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Itlaflix.Infrastructure.Persistence.Contexts;

namespace Itlaflix.Controllers
{
    public class ItlaflixController: Controller
    {
        private readonly SeriesService seriesService;

        public ItlaflixController(ApplicationContext dbContext)
        {
            seriesService = new SeriesService(dbContext);
        }

        public async Task<IActionResult> Index ()
        {
            return View(await seriesService.GetAllViewModel()); ;
        }

        public IActionResult Series () 
        {
            return View();

        }
        [HttpPost]
        //public IActionResult Series(SerieViewModel svm)
        //{
        //    seriesService.add(svm);
        //    return RedirectToRoute(new { Controller = "Itlaflix", action = "index" });
        //    return View();


        //}
        public IActionResult Movies () 
        {
            return View();
        }

        public IActionResult Producer ()
        {
            return View();
        }

        public IActionResult Gender () 
        {
            return View();
        }
    }
}
