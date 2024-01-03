using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.serie;
using Itlaflix.Core.Domain.Entities;

namespace Itlaflix.Core.Application.Services
{
    // Clase que implementa la interfaz ISerieService para proporcionar operaciones específicas de series.
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;

        // Constructor que recibe una implementación de ISerieRepository para la manipulación de datos de series.
        public SerieService(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }
        // Método para agregar una nueva serie utilizando los datos proporcionados por la vista.
        public async Task Add(SaveSerieViewModel vm)
        {
            // Crear una instancia de Serie y asignar valores desde el ViewModel.
            Serie serie = new();
            serie.Name = vm.Name;
            serie.Description = vm.Description;
            serie.director = vm.director;
            serie.imagePath = vm.image;
            serie.year = vm.year;
            serie.ProducerSerie = vm.producer;
            serie.SerieGenders = vm.Gender;

            // Llamar al método de repositorio para agregar la nueva serie a la base de datos.
            await _serieRepository.AssAsync(serie);
        }

        // Método para actualizar una serie existente utilizando los datos proporcionados por la vista.
        public async Task Update(SaveSerieViewModel vm)
        {
            // Crear una instancia de Serie y asignar valores desde el ViewModel.
            Serie serie = new();
            serie.Name = vm.Name;
            serie.Description = vm.Description;
            serie.director = vm.director;
            serie.imagePath = vm.image;
            serie.year = vm.year;
            serie.ProducerSerie = vm.producer;
            serie.SerieGenders = vm.Gender;

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

            // Crear un objeto SaveSerieViewModel y asignar valores desde la serie.
            SaveSerieViewModel vm = new();
            vm.Name = serie.Name;
            vm.Description = serie.Description;
            vm.director = serie.director;
            vm.image = serie.imagePath;
            vm.year = serie.year;
            vm.producer = serie.ProducerSerie;
            vm.Gender = serie.SerieGenders;

            return vm;
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
                Gender = serie.SerieGenders
            }).ToList();
        
    }
    }
}
