using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel.episode
{
    public class EpisodeViewModel
    {
        public int Id { get; set; }
        // Relación con Season
        public Season Season { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
