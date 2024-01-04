
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Itlaflix.Core.Domain.Common;

namespace Itlaflix.Core.Domain.Entities
{
    public class Movie : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        public string url { get; set; }
        public int year { get; set; } 
        public int directorId {  get; set; }
        public Director director {  get; set; }
        public ICollection<ProducerMovie> ProducerMovies { get; set; }

        public ICollection<MovieGender> MovieGenders { get; set; } // Cambiado de Gender a MovieGender
    }
}
