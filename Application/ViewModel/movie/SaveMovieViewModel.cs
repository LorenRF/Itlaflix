using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Application.ViewModel.gender;
using Itlaflix.Core.Application.ViewModel.productor;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel.movie
{
    public class SaveMovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el titulo de la pelicula")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        public ICollection<SerieGender> gender { get; set; }
        [Required(ErrorMessage = "Debe colocar el año de estreno")]
        public int year { get; set; }
        [Required(ErrorMessage = "Debe colocar el director de la pelicula")]
        public Director director { get; set; }
        [Required(ErrorMessage = "Debe colocar la productora de la pelicula")]
        public ICollection<ProducerMovie> ProducerMovies { get; set; }
        [Required(ErrorMessage = "Debe colocar el genero de la pelicula")]
        public ICollection<MovieGender> MovieGenders { get; set; } // Cambiado de Gender a MovieGender
        public ICollection<ProducerSerie> producer { get; set; }
        public List<ProducerViewModel> producerList { get; set; }
        public List<DirectorViewModel> directorList { get; set; }
        public List<GenderViewModel> genderList { get; set; }
    }
}
