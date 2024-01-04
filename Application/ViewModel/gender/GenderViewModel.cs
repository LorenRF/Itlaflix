using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel.gender
{
    public class GenderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SerieGender> SerieGenders { get; set; }

        // Relación con Movies
        public ICollection<MovieGender> MovieGenders { get; set; }
    }
}
