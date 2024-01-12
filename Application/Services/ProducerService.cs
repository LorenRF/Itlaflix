using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.episode;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Application.ViewModel.producer;
using Itlaflix.Core.Domain.Entities;
using System.IO;

namespace Itlaflix.Core.Application.Services
{
    public class ProducerService: IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IProducerSerieRepository _serieProducerRepository;
        private readonly IProducerMovieRepository _movieProducerRepository;
        private readonly ISerieRepository _serieRepository;
        private readonly IMovieRepository _movieRepository;

        public ProducerService(IProducerRepository producerRepository, IProducerSerieRepository
            producerSerieRepository, ISerieRepository serieRepository, IMovieRepository movieRepository
            , IProducerMovieRepository producerMovieRepository)
        {
            _producerRepository = producerRepository;
            _serieProducerRepository = producerSerieRepository;
            _movieProducerRepository = producerMovieRepository; 
            _serieRepository = serieRepository;
            _movieRepository = movieRepository;
        }

        public async Task Add(SaveProducerViewModel vm)
        {
            Producer producer = new();
            producer.Name = vm.Name;

            await _producerRepository.AssAsync(producer);
        }
        public async Task Update(SaveProducerViewModel vm)
        {
            Producer producer = await _producerRepository.GetByIdAsync(vm.Id);
            producer.Name = vm.Name;

            await _producerRepository.UpdateAsync(producer);
        }
        public async Task Delete(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            await _producerRepository.DeleteAsync(producer);
        }

        public async Task<SaveProducerViewModel> GetByIdSaveViewModel(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);

            SaveProducerViewModel vm = new();
            vm.Name = producer.Name;
            vm.Id = producer.Id;

            return vm;
        }

        public async Task<ProducerViewModel> GetByIdViewModel(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            List<ProducerSerie> producerSeries = await _serieProducerRepository.GetAllAsync();
            List<ProducerMovie> producerrMovies = await _movieProducerRepository.GetAllAsync();

            // Obtener todos los SerieId únicos de la lista SerieGender
            var uniqueSerieIds = producerSeries.Select(p => p.SerieId).Distinct().ToList();

            // Obtener todos los MovieId únicos de la lista MovieGender
            var uniqueMovieIds = producerrMovies.Select(p => p.MovieId).Distinct().ToList();

            // Cargar todas las Series y Movies correspondientes a los SerieId y MovieId únicos
            List<Serie> series = new List<Serie>();
            foreach (var i in uniqueSerieIds)
            {
                series.Add(await _serieRepository.GetByIdAsync(i));
            }

            List<Movie> movies = new List<Movie>();
            foreach (var i in uniqueMovieIds)
            {
                movies.Add(await _movieRepository.GetByIdAsync(i));
            }

            // Asignar las referencias a las Series y Movies en genderSeries y genderMovies
            foreach (var serieProducer in producerSeries)
            {
                serieProducer.Serie = series.FirstOrDefault(s => s.Id == serieProducer.SerieId);
            }

            foreach (var movieProducer in producerrMovies)
            {
                movieProducer.Movie = movies.FirstOrDefault(m => m.Id == movieProducer.MovieId);
            }

            ProducerViewModel vm = new();
            vm.Name = producer.Name;
            vm.Id = producer.Id;
            vm.ProducerSeries = producerSeries.Where(p => p.ProducerId == producer.Id).ToList();
            vm.ProducerMovies = producerrMovies.Where(p => p.ProducerId == producer.Id).ToList();

            return vm;
        }

        public async Task<List<ProducerViewModel>> GetAllViewModel()
        {
            var producerList = await _producerRepository.GetAllWithIncludeAsync(new List<string> { "ProducerSeries", "ProducerMovies" });

            return producerList.Select(producer => new ProducerViewModel
            {
                Name = producer.Name,
                ProducerSeries = producer.ProducerSeries,
                ProducerMovies = producer.ProducerMovies,
                Id = producer.Id

            }).ToList();
        }
    }
}
