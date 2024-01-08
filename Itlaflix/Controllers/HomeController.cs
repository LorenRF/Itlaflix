using Microsoft.AspNetCore.Mvc;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Itlaflix.Core.Application.Services;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;

namespace Itlaflix.Controllers
{
    public class HomeController: Controller
    {
        private readonly ISerieService serieService;
        private readonly IMovieService movieService;

        public HomeController(IMovieService ms, ISerieService ss)
        {
            serieService = ss;
            movieService = ms;
        }

        public async Task<IActionResult> Index ()
        {
            var viewmodel = new ConvinedViewModels
            {
                serieList = await serieService.GetAllViewModel(),
                movieList = await movieService.GetAllViewModel()

            };

            return View(viewmodel); 
        }

      
    }
}
