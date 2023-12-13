

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Itlaflix.Core.Domain.Entities
{
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        // Relación con Series
        public ICollection<SerieGender> SerieGenders { get; set; }

        // Relación con Movies
        public ICollection<MovieGender> MovieGenders { get; set; }
    }
}
