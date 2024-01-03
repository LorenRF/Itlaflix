using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Services
{
    public class DirectorService: IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task Add(SaveDirectorViewModel vm)
        {
            Director director = new();
            director.Name = vm.Name;

            await _directorRepository.AssAsync(director);
        }
        public async Task Update(SaveDirectorViewModel vm)
        {
            Director director = new();
            director.Name = vm.Name;

            await _directorRepository.UpdateAsync(director);
        }
        public async Task Delete(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);
            await _directorRepository.DeleteAsync(director);
        }

        public async Task<SaveDirectorViewModel> GetByIdSaveViewModel(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);

            SaveDirectorViewModel vm = new();
            vm.Name = director.Name;

            return vm;
        }

        public async Task<List<DirectorViewModel>> GetAllViewModel()
        {
            var directorList = await _directorRepository.GetAllAsync();

            return directorList.Select(director => new DirectorViewModel
            {
                Name = director.Name,
                DirectedSeries = director.DirectedSeries,
                DirectedMovies = director.DirectedMovies

            }).ToList();
        }
    }
}
