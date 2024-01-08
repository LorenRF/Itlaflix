using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.gender;
using Itlaflix.Core.Domain.Entities;

namespace Itlaflix.Core.Application.Services
{
    public class GenderService: IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly ISerieGenderRepository _SeriegenderRepository;
        private readonly IMovieGenderRepository _MoviegenderRepository;
        private readonly ISerieRepository _serieRepository;
        private readonly IMovieRepository _movieRepository;

        public GenderService(IGenderRepository genderRepository, ISerieGenderRepository SeriegenderRepository, 
            IMovieGenderRepository MoviegenderRepository, ISerieRepository serieRepository, IMovieRepository movieRepository)
        {
            _genderRepository = genderRepository;
            _SeriegenderRepository = SeriegenderRepository;
            _MoviegenderRepository = MoviegenderRepository;
            _serieRepository = serieRepository;
            _movieRepository = movieRepository;
        }

        public async Task Add(SaveGenderViewModel vm)
        {
            Gender gender = new();
            gender.Name = vm.Name;
           

            await _genderRepository.AssAsync(gender);
        }
        public async Task Update(SaveGenderViewModel vm)
        {   
            
            Gender gender = await _genderRepository.GetByIdAsync(vm.Id);
            gender.Name = vm.Name;
            gender.Id = vm.Id;

            await _genderRepository.UpdateAsync(gender);
        }
        public async Task Delete(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);
            await _genderRepository.DeleteAsync(gender);
        }

        public async Task<SaveGenderViewModel> GetByIdSaveViewModel(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);

            SaveGenderViewModel vm = new();
            vm.Name = gender.Name;
            vm.Id = gender.Id;

            return vm;
        }

        public async Task<GenderViewModel> GetByIdViewModel(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);
            List<SerieGender> genderSeries = await _SeriegenderRepository.GetAllAsync();
            List<MovieGender> genderMovies = await _MoviegenderRepository.GetAllAsync();

            // Obtener todos los SerieId únicos de la lista SerieGender
            var uniqueSerieIds = genderSeries.Select(g => g.SerieId).Distinct().ToList();

            // Obtener todos los MovieId únicos de la lista MovieGender
            var uniqueMovieIds = genderMovies.Select(g => g.MovieId).Distinct().ToList();

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
            foreach (var serieGender in genderSeries)
            {
                serieGender.Serie = series.FirstOrDefault(s => s.Id == serieGender.SerieId);
            }

            foreach (var movieGender in genderMovies)
            {
                movieGender.Movie = movies.FirstOrDefault(m => m.Id == movieGender.MovieId);
            }

            GenderViewModel vm = new();
            vm.Name = gender.Name;
            vm.Id = gender.Id;
            vm.SerieGenders = genderSeries.Where(g => g.GenderId == gender.Id).ToList();
            vm.MovieGenders = genderMovies.Where(g => g.GenderId == gender.Id).ToList();

            return vm;
        }

        public async Task<List<GenderViewModel>> GetAllViewModel()
        {
            var genderList = await _genderRepository.GetAllAsync();

            return genderList.Select(gender => new GenderViewModel
            {
                Name = gender.Name,
                SerieGenders = gender.SerieGenders,
                MovieGenders = gender.MovieGenders,
                Id = gender.Id

            }).ToList();
        }
    }
}
