// Entidad Serie en el dominio de entidades.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Itlaflix.Core.Domain.Common;

namespace Itlaflix.Core.Domain.Entities
{
    public class Serie : AuditableBaseEntity
    {
        // Nombre de la serie.
        public string Name { get; set; }

        // Descripción de la serie.
        public string Description { get; set; }

        // Ruta de la imagen asociada a la serie.
        public string imagePath { get; set; }

        // Año de lanzamiento de la serie.
        public int year { get; set; }

        // Número de temporadas de la serie.
        public int Temporadas { get; set; }

        // Identificador del director de la serie en la base de datos.
        public int directorId { get; set; }

        // Referencia a la entidad Director que representa al director de la serie.
        public Director director { get; set; }

        // Colección de temporadas asociadas a la serie.
        public ICollection<Season> Seasons { get; set; }

        // Colección de relaciones entre la serie y los productores asociados.
        public ICollection<ProducerSerie> ProducerSerie { get; set; }

        // Colección de relaciones entre la serie y los géneros asociados.
        public ICollection<SerieGender> SerieGenders { get; set; }
    }
}
