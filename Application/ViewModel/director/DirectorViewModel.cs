using Itlaflix.Core.Domain.Entities;


namespace Itlaflix.Core.Application.ViewModel.director
{
    public class DirectorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Serie> DirectedSeries { get; set; }
        public ICollection<Movie> DirectedMovies { get; set; }
    }
}
