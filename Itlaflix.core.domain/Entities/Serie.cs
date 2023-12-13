
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Itlaflix.Core.Domain.Entities
{
    public class Serie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        public int year { get; set; }
        public int temporadas { get; set; }
        public int directorId { get; set; }
        public Director director { get; set; }
        public ICollection<ProducerSerie> ProducerSerie { get; set; }

        public ICollection<SerieGender> SerieGenders { get; set; }
    }
}
