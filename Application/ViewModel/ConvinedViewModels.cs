using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Application.ViewModel.gender;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Application.ViewModel.producer;

namespace Itlaflix.Core.Application.ViewModel
{
    public class ConvinedViewModels
    {
        public DirectorViewModel directorViewModel { get; set; }
        public GenderViewModel genderviewmodel { get; set; }
        public ProducerViewModel producerviewmodel { get; set; }
        public SaveSerieViewModel saveserieViewmodel { get; set; }
        public SaveMovieViewModel Savemovieviewmodel { get; set; }

    }
}
