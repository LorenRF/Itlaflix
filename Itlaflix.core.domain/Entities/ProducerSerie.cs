using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Domain.Entities
{
    public class ProducerSerie
    {
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        public int SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}
