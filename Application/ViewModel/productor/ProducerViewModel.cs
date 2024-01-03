using Itlaflix.Core.Domain.Entities;


namespace Itlaflix.Core.Application.ViewModel.productor
{
    public class ProducerViewModel
    {
        public string Name { get; set; }
        public ICollection<ProducerSerie> ProducerSeries { get; set; }
        public ICollection<ProducerMovie> ProducerMovies { get; set; }
    }
}
