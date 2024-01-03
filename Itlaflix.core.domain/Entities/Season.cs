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
    public class Season : AuditableBaseEntity
    {
       
        public int SeasonNumber { get; set; }

        // Relación con Serie
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        // Relación con Episode
        public ICollection<Episode> Episodes { get; set; }
    }
}
