using Microsoft.AspNetCore.Mvc;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Itlaflix.Core.Application.Services;
using Itlaflix.Core.Application.Interfaces.Services;

namespace Itlaflix.Controllers
{
    public class HomeController: Controller
    {
        private readonly ISerieService serieService;
        //private readonly IMovieService movieService;

        public HomeController(/*IMovieService ms,*/ ISerieService ss)
        {
            serieService = ss;
            //movieService = ms; 
        }

        public async Task<IActionResult> Index ()
        {
            return View(await serieService.GetAllViewModel()); 
        }

        //public IActionResult Series () 
        //{
        //    return View();

        //}
        //[HttpPost]
        ////public IActionResult Series(SerieViewModel svm)
        ////{
        ////    seriesService.add(svm);
        ////    return RedirectToRoute(new { Controller = "Itlaflix", action = "index" });
        ////    return View();


        ////}
        //public IActionResult Movies () 
        //{
        //    return View();
        //}

        //public IActionResult Producer ()
        //{
        //    return View();
        //}

        //public IActionResult Gender () 
        //{
        //    return View();
        //}
    }
}
