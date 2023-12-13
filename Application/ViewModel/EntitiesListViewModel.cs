using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel
{
    public class EntitiesListViewModel
    {
        public List<SerieViewModel> series { get; set; } = new ();
        public List<GenderViewModel> Generos { get; set; } = new ();
        public List<ProducerViewModel> Producers { get; set; } = new ();
    }
}
