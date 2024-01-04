using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel.movie
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string url { get; set; }
        public string imagePath { get; set; }
        public int year { get; set; }
        public Director director { get; set; }
        public ICollection<ProducerMovie> ProducerMovies { get; set; }

        public ICollection<MovieGender> MovieGenders { get; set; } // Cambiado de Gender a MovieGender
    }
}
