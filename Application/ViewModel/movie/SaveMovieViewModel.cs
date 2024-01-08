using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Application.ViewModel.gender;
using Itlaflix.Core.Application.ViewModel.producer;
using Itlaflix.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace Itlaflix.Core.Application.ViewModel.movie
{
    public class SaveMovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el titulo de la pelicula")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string url { get; set; }
        public string imagePath { get; set; }
        [Required(ErrorMessage = "Debe colocar el año de estreno")]
        public int year { get; set; }
        [Required(ErrorMessage = "Debe colocar el director de la pelicula")]
        public int directorId { get; set; }
        [Required(ErrorMessage = "Debe colocar la productora de la pelicula")]
        public List<int> ProducersId { get; set; }
        [Required(ErrorMessage = "Debe colocar el genero de la pelicula")]
        public List<int> GendersId { get; set; } // Cambiado de Gender a MovieGender
        public List<ProducerViewModel> producerList { get; set; }
        public List<DirectorViewModel> directorList { get; set; }
        public List<GenderViewModel> genderList { get; set; }
    }
}
