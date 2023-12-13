using Itlaflix.Infrastructure.Persistence.Services;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Controllers
{
    public class SerieController : Controller
    {
        private readonly SeriesService seriesService;

        public SerieController (ApplicationContext dbContext)
        {
            seriesService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await seriesService.GetAllViewModel());
        }
    }
}
