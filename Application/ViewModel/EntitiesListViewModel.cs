using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Application.ViewModel.gender;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Application.ViewModel.productor;
using Itlaflix.Core.Application.ViewModel.serie;

namespace Itlaflix.Core.Application.ViewModel
{
    public class EntitiesListViewModel
    {
        public List<SerieViewModel> series { get; set; } = new ();
        public List<MovieViewModel> movies { get; set; } = new();
        public List<DirectorViewModel> directores { get; set; } = new();
        public List<GenderViewModel> Generos { get; set; } = new ();
        public List<ProducerViewModel> Producers { get; set; } = new ();
    }
}
