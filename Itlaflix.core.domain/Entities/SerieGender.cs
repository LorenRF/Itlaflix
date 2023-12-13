using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Domain.Entities
{
    public class SerieGender
    {
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
