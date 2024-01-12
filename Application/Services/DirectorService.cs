using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Domain.Entities;
using System.Linq;


namespace Itlaflix.Core.Application.Services
{
    public class DirectorService: IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMovieRepository _MovieRepository;
        private readonly ISerieRepository _SerieRepository;

        public DirectorService(IDirectorRepository directorRepository, IMovieRepository movieRepository, ISerieRepository serieRepository)
        {
            _directorRepository = directorRepository;
            _MovieRepository = movieRepository;
            _SerieRepository = serieRepository;
        }

        public async Task Add(SaveDirectorViewModel vm)
        {
            Director director = new();
            director.Name = vm.Name;

            await _directorRepository.AssAsync(director);
        }
        public async Task Update(SaveDirectorViewModel vm)
        {
            Director director = await _directorRepository.GetByIdAsync(vm.Id);
            director.Name = vm.Name;

            await _directorRepository.UpdateAsync(director);
        }
        public async Task Delete(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);
            await _directorRepository.DeleteAsync(director);
        }

        public async Task<SaveDirectorViewModel> GetByIdSaveViewModel(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);

            SaveDirectorViewModel vm = new();
            vm.Name = director.Name;
            vm.Id = director.Id;

            return vm;
        }

        public async Task<DirectorViewModel> GetByIdViewModel(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);
            List<Serie> directedSeries = await _SerieRepository.GetAllAsync();
            List<Movie> directedMovies = await _MovieRepository.GetAllAsync();

            

            DirectorViewModel vm = new();
            vm.Name = director.Name;
            vm.Id = director.Id;
            vm.DirectedSeries = directedSeries.Where(d => d.directorId == director.Id).ToList();
            vm.DirectedMovies = directedMovies.Where(d => d.directorId == director.Id).ToList();

            return vm;
        }


        public async Task<List<DirectorViewModel>> GetAllViewModel()
        {
            var directorList = await _directorRepository.GetAllWithIncludeAsync(new List<string> { "DirectedSeries", "DirectedMovies" });

            return directorList.Select(director => new DirectorViewModel
            {
                Name = director.Name,
                DirectedSeries = director.DirectedSeries.ToList(),
                DirectedMovies = director.DirectedMovies.ToList(),
                Id = director.Id

            }).ToList();
        }
    }
}
