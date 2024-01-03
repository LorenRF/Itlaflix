using Itlaflix.Core.Domain.Entities;

namespace Itlaflix.Core.Application.ViewModel.season
{
    public class SeasonViewModel
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }

        public Serie Serie { get; set; }

        // Relación con Episode
        public ICollection<Episode> Episodes { get; set; }
    }
}
