using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Application.ViewModel.serie;
using Itlaflix.Core.Domain.Entities;
using System.IO;

namespace Itlaflix.Core.Application.Services
{
    // Clase que implementa la interfaz ISerieService para proporcionar operaciones específicas de series.
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly ISerieGenderRepository _serieGenderRepository;
        private readonly IProducerSerieRepository _producerSerieRepository;

        public SerieService(ISerieRepository serieRepository, IDirectorRepository directorRepository, IProducerRepository producerRepository, IGenderRepository genderRepository, ISerieGenderRepository movieGenderRepository, IProducerSerieRepository producerMovieRepository)
        {
            _serieRepository = serieRepository;
            _directorRepository = directorRepository;
            _producerRepository = producerRepository;
            _genderRepository = genderRepository;
            _serieGenderRepository = movieGenderRepository;
            _producerSerieRepository = producerMovieRepository;
        }
        // Método para agregar una nueva serie utilizando los datos proporcionados por la vista.
        public async Task Add(SaveSerieViewModel vm)
        {
            ICollection<SerieGender> gendersCollection = new HashSet<SerieGender>();
            ICollection<ProducerSerie> producersCollection = new HashSet<ProducerSerie>();

            Director director = await _directorRepository.GetByIdAsync(vm.directorId);

            foreach (var genderid in vm.GendersId)
            {
                SerieGender mg = new SerieGender
                {
                    GenderId = genderid
                };

                gendersCollection.Add(mg);
            }

            foreach (var producerid in vm.ProducersId)
            {
                ProducerSerie sp = new ProducerSerie
                {
                    ProducerId = producerid
                };

                producersCollection.Add(sp);
            }
            // Crear una instancia de Serie y asignar valores desde el ViewModel.
            Serie serie = new();
            serie.Name = vm.Name;
            serie.Description = vm.Description;
            serie.directorId = vm.directorId;
            serie.imagePath = vm.image;
            serie.year = vm.year;
            serie.ProducerSerie = producersCollection;
            serie.SerieGenders = gendersCollection;

            // Llamar al método de repositorio para agregar la nueva serie a la base de datos.
            await _serieRepository.AssAsync(serie);
        }

        // Método para actualizar una serie existente utilizando los datos proporcionados por la vista.
        public async Task Update(SaveSerieViewModel vm)
        {
            Director director = await _directorRepository.GetByIdAsync(vm.directorId);

            Serie serie = await _serieRepository.GetByIdAsync(vm.Id);

            // Eliminar relaciones existentes en MovieGender
            var existingserieGenders = await _serieGenderRepository.GetAllAsync();

            foreach (SerieGender movieGender in existingserieGenders)
            {
                await _serieGenderRepository.DeleteAsync(movieGender);
            }

            // Eliminar relaciones existentes en ProducerMovie
            var existingProducerSeries = await _producerSerieRepository.GetAllAsync();
            foreach (ProducerSerie producerSerie in existingProducerSeries)
            {
                await _producerSerieRepository.DeleteAsync(producerSerie);
            }

            ICollection<SerieGender> gendersCollection = new HashSet<SerieGender>();
            ICollection<ProducerSerie> producersCollection = new HashSet<ProducerSerie>();

            foreach (var genderid in vm.GendersId)
            {
                SerieGender mg = new SerieGender
                {
                    GenderId = genderid
                };

                gendersCollection.Add(mg);
            }

            foreach (var producerid in vm.ProducersId)
            {
                ProducerSerie sp = new ProducerSerie
                {
                    ProducerId = producerid
                };

                producersCollection.Add(sp);
            }

            //// mediante el id busca la serie a modificar y solo aplica los cambios necesarios a esta
            serie.Name = vm.Name;
            serie.Description = vm.Description; 
            serie.directorId = vm.directorId;
            serie.director = director;
            serie.imagePath = vm.image;
            serie.year = vm.year;
            serie.ProducerSerie = producersCollection;
            serie.SerieGenders = gendersCollection;

            // Llamar al método de repositorio para actualizar la serie en la base de datos.
            await _serieRepository.UpdateAsync(serie);
        }

        // Método para eliminar una serie existente según su identificador.
        public async Task Delete(int id)
        {
            // Obtener la serie por su identificador.
            var serie = await _serieRepository.GetByIdAsync(id);

            // Llamar al método de repositorio para eliminar la serie de la base de datos.
            await _serieRepository.DeleteAsync(serie);
        }

        // Método para obtener un objeto SaveSerieViewModel por su identificador.
        public async Task<SaveSerieViewModel> GetByIdSaveViewModel(int id)
        {
            // Obtener la serie por su identificador.
            var serie = await _serieRepository.GetByIdAsync(id);
            List<SerieGender> serieGenders = await _serieGenderRepository.GetAllAsync();
            List<ProducerSerie> producerSeries = await _producerSerieRepository.GetAllAsync();

            List<int> gendersid = new List<int>();
            List<int> producersid = new List<int>();

            foreach (var gender in serieGenders)
            {
                gendersid.Add(gender.GenderId);
            }
            foreach (var producer in producerSeries)
            {
                producersid.Add(producer.ProducerId);
            }
            // Crear un objeto SaveSerieViewModel y asignar valores desde la serie.
            SaveSerieViewModel vm = new();
            vm.Name = serie.Name;
            vm.Description = serie.Description;
            vm.directorId = serie.directorId;
            vm.image = serie.imagePath;
            vm.year = serie.year;
            vm.ProducersId = producersid;
            vm.GendersId = gendersid;
            vm.Id = serie.Id;
            return vm;
        }

        public async Task<SerieViewModel> GetByIdViewModel(int id)
        {
            //// Obtener la serie por su identificador.
            //var serie = await _serieRepository.GetByIdAsync(id);
            //List<MovieGender> movieGenders = await _serieGenderRepository.GetAllAsync();
            //List<ProducerMovie> producerMovies = await _producerSerieRepository.GetAllAsync();
            //List<ProducerMovie> producers = new List<ProducerMovie>();


            //foreach (var producer in producerMovies)
            //{
            //    producers.Add(producer);
            //}

            //var gender = await _genderRepository.GetByIdAsync(id);
            //List<MovieGender> genderMovies = await _seriegenderRepository.GetAllAsync();



            //SerieViewModel vm = new();
            //vm.Name = serie.Name;
            //vm.Description = serie.Description;
            //vm.image = serie.imagePath;
            //vm.year = serie.year;
            //vm.Producer = producers;
            //vm.Id = serie.Id;
            //vm.MovieGenders = (List<MovieGender>)genderMovies.Where(g => g.GenderId == gender.Id);

            //return vm;

            return null;
        }

        // Método para obtener una lista de objetos SerieViewModel con información de todas las series.
        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            // Obtener la lista de todas las series desde el repositorio.
            var serieList = await _serieRepository.GetAllAsync();

            // Mapear la lista de series a una lista de SerieViewModel.
            return serieList.Select(serie => new SerieViewModel
            {
                Name = serie.Name,
                Description = serie.Description,
                director = serie.director,
                image = serie.imagePath,
                year = serie.year,
                Producer = serie.ProducerSerie,
                Gender = serie.SerieGenders,
                Id = serie.Id
            }).ToList();
        
    }
    }
}
