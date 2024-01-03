using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itlaflix.Core.Domain.Common;

namespace Itlaflix.Core.Domain.Entities
{
    public class Director: AuditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Serie> DirectedSeries { get; set; }
        public ICollection<Movie> DirectedMovies { get; set; }
    }
}
