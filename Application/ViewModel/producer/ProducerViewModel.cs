using Itlaflix.Core.Domain.Entities;


namespace Itlaflix.Core.Application.ViewModel.producer
{
    public class ProducerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProducerSerie> ProducerSeries { get; set; }
        public ICollection<ProducerMovie> ProducerMovies { get; set; }
    }
}
