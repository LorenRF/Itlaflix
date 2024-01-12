using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Application.ViewModel.serie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Interfaces.Services
{
    public interface IMovieService : IGenericService<SaveMovieViewModel, MovieViewModel>
    {
        Task<List<MovieViewModel>> filtredAllViewModel(FilterMoviesViewModel filter);
    }
}
