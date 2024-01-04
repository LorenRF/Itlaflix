using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task Add(SaveMovieViewModel vm)
        {
            Movie movie = new();
            movie.Name = vm.Name;
            movie.Description = vm.Description;
            movie.director = vm.director;
            movie.imagePath = vm.imagePath;
            movie.year = vm.year;
            movie.ProducerMovies = vm.ProducerMovies;
            movie.MovieGenders = vm.MovieGenders;
            movie.url = vm.url;

            await _movieRepository.AssAsync(movie);
        }
        public async Task Update(SaveMovieViewModel vm)
        {
            Movie movie = new();
            movie.Name = vm.Name;
            movie.Description = vm.Description;
            movie.director = vm.director;
            movie.imagePath = vm.imagePath;
            movie.year = vm.year;
            movie.ProducerMovies = vm.ProducerMovies;
            movie.MovieGenders = vm.MovieGenders;
            movie.url = vm.url;

            await _movieRepository.UpdateAsync(movie);
        }
        public async Task Delete(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            await _movieRepository.DeleteAsync(movie);
        }

        public async Task<SaveMovieViewModel> GetByIdSaveViewModel(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            SaveMovieViewModel vm = new();
            vm.Name = movie.Name;
            vm.Description = movie.Description;
            vm.director = movie.director;
            vm.imagePath = movie.imagePath;
            vm.year = movie.year;
            vm.ProducerMovies = movie.ProducerMovies;
            vm.MovieGenders = movie.MovieGenders;
            vm.url = movie.url;
            return vm;
        }

        public async Task<List<MovieViewModel>> GetAllViewModel()
        {
            var movieList = await _movieRepository.GetAllAsync();

            return movieList.Select(movie => new MovieViewModel
            {
                Name = movie.Name,
                Description = movie.Description,
                director = movie.director,
                imagePath = movie.imagePath,
                year = movie.year,
                ProducerMovies = movie.ProducerMovies,
                MovieGenders = movie.MovieGenders,
                url = movie.url


            }).ToList();
        }
    }
}
