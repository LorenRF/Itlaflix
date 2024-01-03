using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel.season
{
    public class SaveSeasonViewModel
    {
        [Required(ErrorMessage = "Debe colocar el numero de la temporada")]
        public int SeasonNumber { get; set; }
        [Required(ErrorMessage = "Debe colocar la serie a la que pertenece a temporada")]
        public Serie Serie { get; set; }

    }
}
