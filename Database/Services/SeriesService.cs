using Itlaflix.Infrastructure.Persistence.Repositories;
using Itlaflix.Core.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using Itlaflix.Infrastructure.Persistence.Contexts;

namespace Itlaflix.Infrastructure.Persistence.Services ///esta clase debe ser eliminada y solo usar la que se encuentra en application
{
    public class SeriesService
    {
        private readonly SeriesRepository seriesRepository;

        public SeriesService(ApplicationContext context)
        {
            seriesRepository = new(context);
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var series = await seriesRepository.GetSeries();
            return series.Select(serie => new SerieViewModel
            {
                Name = serie.Name,
                Description = serie.Description,
                directorId = serie.directorId,
                year = serie.year,
                temporadas = serie.temporadas,
                image = serie.imagePath,
                director = serie.director,
                Id  = serie.Id
            }).ToList();
        }

        //public void add(SerieViewModel serie)
        //{
        //    SeriesRepository.Instance.EntitiesListViewModel.series.Add(serie);
        //}
    }
}
