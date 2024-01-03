// Clase AuditableBaseEntity en el dominio común que proporciona atributos comunes para todas las entidades.
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Itlaflix.Core.Domain.Common
{
    public class AuditableBaseEntity
    {
        // Identificador único de la entidad.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        // Usuario que creó la entidad.
        public string createdBy { get; set; }

        // Fecha y hora en que se creó la entidad.
        public DateTime created { get; set; }

        // Usuario que modificó la entidad.
        public string modifiedBy { get; set; }

        // Fecha y hora de la última modificación de la entidad.
        public DateTime? modified { get; set; }
    }
}
