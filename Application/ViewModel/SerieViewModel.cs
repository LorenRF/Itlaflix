using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.ViewModel
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GenderViewModel> Gender { get; set; }
        public string image { get; set; }
        public int year { get; set; }
        public int temporadas { get; set; }
        public int directorId { get; set; }
        public Director director { get; set; }
        public ProducerViewModel Producer { get; set; }
    }
}
