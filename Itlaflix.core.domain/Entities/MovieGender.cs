// Entidad MovieGender
namespace Itlaflix.Core.Domain.Entities
{
    // Clase que representa la relación entre las entidades Movie y Gender
    public class MovieGender
    {
        // Propiedad que sirve como clave foránea para la relación con Movie
        public int MovieId { get; set; }

        // Propiedad de navegación a la entidad Movie
        public Movie Movie { get; set; }

        // Propiedad que sirve como clave foránea para la relación con Gender
        public int GenderId { get; set; }

        // Propiedad de navegación a la entidad Gender
        public Gender Gender { get; set; }
    }
}
