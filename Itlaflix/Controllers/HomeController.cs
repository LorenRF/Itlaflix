using Microsoft.AspNetCore.Mvc;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Itlaflix.Core.Application.ViewModel.serie;

namespace Itlaflix.Controllers
{
    public class HomeController: Controller
    {
        private readonly ISerieService serieService;
        private readonly IMovieService movieService;
        private readonly IGenderService genderService;


        public HomeController(IMovieService ms, ISerieService ss, IGenderService gs)
        {
            serieService = ss;
            movieService = ms;
            genderService = gs;
        }

        public async Task<IActionResult> Index (FilterMoviesViewModel? mvm, FilterSeriesViewModel? vm)
        {

            ViewBag.genderList = await genderService.GetAllViewModel();
            ViewBag.movieList = await movieService.filtredAllViewModel(mvm);

            return View(await serieService.filtredAllViewModel(vm)); 
        }

      
    }
}
