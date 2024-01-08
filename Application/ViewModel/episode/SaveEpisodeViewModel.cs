using Itlaflix.Core.Application.ViewModel.season;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel.episode
{
    public class SaveEpisodeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar El numero del episodio")]

        public int episodeNumber { get; set; }

        [Required(ErrorMessage = "Debe colocar la temporada a la que pertenece este episodio")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        [Required(ErrorMessage = "Debe colocar el titulo del episodio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar el link del episodio")]
        public string url { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        [Required(ErrorMessage = "Debe colocar la fecha de publicación")]
        public DateTime ReleaseDate { get; set; }
        public List<SeasonViewModel> seasonList { get; set; }
    }
}
