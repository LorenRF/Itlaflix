using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Domain.Entities
{
    public class ProducerMovie
    {
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
