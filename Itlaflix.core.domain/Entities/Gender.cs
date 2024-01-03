

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Itlaflix.Core.Domain.Common;

namespace Itlaflix.Core.Domain.Entities
{
    public class Gender : AuditableBaseEntity
    {
        
        public string Name { get; set; }

        // Relación con Series
        public ICollection<SerieGender> SerieGenders { get; set; }

        // Relación con Movies
        public ICollection<MovieGender> MovieGenders { get; set; }
    }
}
