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
    public class Episode : AuditableBaseEntity
    {
       
        // Relación con Season
        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
