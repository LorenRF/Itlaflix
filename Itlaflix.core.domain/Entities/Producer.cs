
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Itlaflix.Core.Domain.Entities
{
    public class Producer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProducerSerie> ProducerSeries { get; set; }
        public ICollection<ProducerMovie> ProducerMovies { get; set; }


    }
}
