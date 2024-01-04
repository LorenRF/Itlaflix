using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel.producer
{
    public class SaveProducerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre de la productora")]
        public string Name { get; set; }
    }
}
