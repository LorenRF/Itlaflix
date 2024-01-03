// Entidad SerieGender
namespace Itlaflix.Core.Domain.Entities
{
    // Clase que representa la relación entre las entidades Serie y Gender
    public class SerieGender
    {
        // Propiedad que sirve como clave foránea para la relación con Serie
        public int SerieId { get; set; }

        // Propiedad de navegación a la entidad Serie
        public Serie Serie { get; set; }

        // Propiedad que sirve como clave foránea para la relación con Gender
        public int GenderId { get; set; }

        // Propiedad de navegación a la entidad Gender
        public Gender Gender { get; set; }
    }
}
