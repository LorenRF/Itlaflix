// Entidad ProducerMovie
namespace Itlaflix.Core.Domain.Entities
{
    // Clase que representa la relación entre las entidades Producer y Movie
    public class ProducerMovie
    {
        // Propiedad que sirve como clave foránea para la relación con Producer
        public int ProducerId { get; set; }

        // Propiedad de navegación a la entidad Producer
        public Producer Producer { get; set; }

        // Propiedad que sirve como clave foránea para la relación con Movie
        public int MovieId { get; set; }

        // Propiedad de navegación a la entidad Movie
        public Movie Movie { get; set; }
    }
}
