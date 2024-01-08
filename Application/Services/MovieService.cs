using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Domain.Entities;

namespace Itlaflix.Core.Application.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IMovieGenderRepository _movieGenderRepository;
        private readonly IProducerMovieRepository _producerMovieRepository;
        private readonly ISerieGenderRepository _SeriegenderRepository;
        private readonly IMovieGenderRepository _MoviegenderRepository;

        public MovieService(IMovieRepository movieRepository, IDirectorRepository directorRepository, 
            IProducerRepository producerRepository, IGenderRepository genderRepository, 
            IMovieGenderRepository movieGenderRepository, IProducerMovieRepository producerMovieRepository,
            ISerieGenderRepository SeriegenderRepository, IMovieGenderRepository MoviegenderRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _producerRepository = producerRepository;
            _genderRepository = genderRepository;
            _movieGenderRepository = movieGenderRepository;
            _producerMovieRepository = producerMovieRepository;
            _SeriegenderRepository = SeriegenderRepository;
            _movieGenderRepository = movieGenderRepository;
        }

        public async Task Add(SaveMovieViewModel vm)
        {
            ICollection<MovieGender> gendersCollection = new HashSet<MovieGender>();
            ICollection<ProducerMovie> producersCollection = new HashSet<ProducerMovie>();
            Director director = await _directorRepository.GetByIdAsync(vm.directorId);

            foreach (var genderid in vm.GendersId)
            {
                MovieGender mg = new MovieGender
                {
                    GenderId = genderid
                };

                gendersCollection.Add(mg);
            }

            foreach (var producerid in vm.ProducersId)
            {
                ProducerMovie mp = new ProducerMovie
                {
                    ProducerId = producerid
                };

                producersCollection.Add(mp);
            }
            Movie movie = new();
            movie.Name = vm.Name;
            movie.Description = vm.Description;
            movie.directorId = vm.directorId;
            movie.imagePath = vm.imagePath;
            movie.year = vm.year;
            movie.ProducerMovies =producersCollection;
            movie.MovieGenders = gendersCollection;
            movie.director = director;
            movie.url = vm.url;

            await _movieRepository.AssAsync(movie);
        }
        public async Task Update(SaveMovieViewModel vm)
        {
            Director director = await _directorRepository.GetByIdAsync(vm.directorId);

            Movie movie = await _movieRepository.GetByIdAsync(vm.Id);

            // Eliminar relaciones existentes en MovieGender
            var existingMovieGenders = await _movieGenderRepository.GetAllAsync();

            foreach(MovieGender movieGender in existingMovieGenders)
            {
                await _movieGenderRepository.DeleteAsync(movieGender);
            }

            // Eliminar relaciones existentes en ProducerMovie
            var existingProducerMovies = await _producerMovieRepository.GetAllAsync();
            foreach (ProducerMovie producerMovie in existingProducerMovies)
            {
                await _producerMovieRepository.DeleteAsync(producerMovie);
            }

            ICollection<MovieGender> gendersCollection = new HashSet<MovieGender>();
            ICollection<ProducerMovie> producersCollection = new HashSet<ProducerMovie>();

            foreach (var genderid in vm.GendersId)
            {
                Gender gender = await _genderRepository.GetByIdAsync(genderid);

                MovieGender mg = new MovieGender
                {
                    MovieId = vm.Id,
                    Movie = movie,
                    GenderId = genderid,
                    Gender = gender
                    
                };

                gendersCollection.Add(mg);
            }
            foreach (var producerid in vm.ProducersId)
            {
                Producer producer = await _producerRepository.GetByIdAsync(producerid);

                ProducerMovie mp = new ProducerMovie
                {
                    MovieId = vm.Id,
                    Movie = movie,
                    ProducerId = producerid,
                    Producer = producer
                };

                producersCollection.Add(mp);
            }

            movie.Name = vm.Name;
            movie.Description = vm.Description;
            movie.directorId = vm.directorId;
            movie.director = director;
            movie.imagePath = vm.imagePath;
            movie.year = vm.year;
            movie.ProducerMovies = producersCollection;
            movie.MovieGenders = gendersCollection;
            movie.url = vm.url;

            await _movieRepository.UpdateAsync(movie);
        }
        public async Task Delete(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            await _movieRepository.DeleteAsync(movie);
        }

        public async Task<SaveMovieViewModel> GetByIdSaveViewModel(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            List<MovieGender> movieGenders = await _movieGenderRepository.GetAllAsync();
            List<ProducerMovie> producerMovies = await _producerMovieRepository.GetAllAsync();

            List<int> gendersid = new List<int>();
            List<int> producersid = new List<int>();

            foreach (var gender in movieGenders)
            {
                gendersid.Add(gender.GenderId);
            }
            foreach (var producer in producerMovies)
            {
                producersid.Add(producer.ProducerId);
            }

            SaveMovieViewModel vm = new();
            vm.Name = movie.Name;
            vm.Description = movie.Description;
            vm.directorId = movie.directorId;
            vm.imagePath = movie.imagePath;
            vm.year = movie.year;
            vm.ProducersId = producersid;
            vm.GendersId = gendersid;
            vm.url = movie.url;
            vm.Id = movie.Id;
            return vm;
        }

        public async Task<MovieViewModel> GetByIdViewModel(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            List<MovieGender> movieGenders = await _movieGenderRepository.GetAllAsync();
            List<ProducerMovie> producerMovies = await _producerMovieRepository.GetAllAsync();
            List<ProducerMovie> producers = new List<ProducerMovie>();

            
            foreach (var producer in producerMovies)
            {
                producers.Add(producer);
            }

            var gender = await _genderRepository.GetByIdAsync(id);
            List<MovieGender> genderMovies = await _MoviegenderRepository.GetAllAsync();



            MovieViewModel vm = new();
            vm.Name = movie.Name;
            vm.Description = movie.Description;
            vm.imagePath = movie.imagePath;
            vm.year = movie.year;
            vm.ProducerMovies = producers;
            vm.url = movie.url;
            vm.Id = movie.Id;
            vm.MovieGenders = genderMovies.Where(g => g.GenderId == gender.Id).ToList();

            return vm;
        }

        public async Task<List<MovieViewModel>> GetAllViewModel()
        {
            var movieList = await _movieRepository.GetAllAsync();

            return movieList.Select(movie => new MovieViewModel
            {
                Name = movie.Name,
                Description = movie.Description,
                director = movie.director,
                imagePath = movie.imagePath,
                year = movie.year,
                ProducerMovies = movie.ProducerMovies,
                MovieGenders = movie.MovieGenders,
                url = movie.url,
                Id = movie.Id


            }).ToList();
        }
    }
}
