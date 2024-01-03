using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel.director
{
    public class SaveDirectorViewModel
    {   
        [Required(ErrorMessage = "Debe colocar el nombre del director")]
        public string Name { get; set; }
        

    }
}
