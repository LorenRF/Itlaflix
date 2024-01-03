
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Itlaflix.Core.Domain.Common;

namespace Itlaflix.Core.Domain.Entities
{
    public class Producer : AuditableBaseEntity
    {
       
        public string Name { get; set; }
        public ICollection<ProducerSerie> ProducerSeries { get; set; }
        public ICollection<ProducerMovie> ProducerMovies { get; set; }


    }
}
