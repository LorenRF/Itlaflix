// Entidad ProducerSerie
namespace Itlaflix.Core.Domain.Entities
{
    // Clase que representa la relación entre las entidades Producer y Serie
    public class ProducerSerie
    {
        // Propiedad que sirve como clave foránea para la relación con Producer
        public int ProducerId { get; set; }

        // Propiedad de navegación a la entidad Producer
        public Producer Producer { get; set; }

        // Propiedad que sirve como clave foránea para la relación con Serie
        public int SerieId { get; set; }

        // Propiedad de navegación a la entidad Serie
        public Serie Serie { get; set; }
    }
}
