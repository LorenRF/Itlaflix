// Clase SerieViewModel para representar la información de una serie en la vista.
using Itlaflix.Core.Domain.Entities;

namespace Itlaflix.Core.Application.ViewModel.serie
{
    public class SerieViewModel
    {
        // Identificador único de la serie.
        public int Id { get; set; }

        // Nombre de la serie.
        public string Name { get; set; }

        // Descripción de la serie.
        public string Description { get; set; }

        // Géneros asociados a la serie.
        public ICollection<SerieGender> Gender { get; set; }

        // Ruta de la imagen de la serie.
        public string image { get; set; }

        // Año de lanzamiento de la serie.
        public int year { get; set; }

        // Número de temporadas de la serie.
        public ICollection<Season> Seasons { get; set; }

        // Director de la serie.
        public Director director { get; set; }

        // Productores asociados a la serie.
        public ICollection<ProducerSerie> Producer { get; set; }
        public ICollection<SerieGender> SerieGenders { get; set; }
    }
}