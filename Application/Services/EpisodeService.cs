using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.episode;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Services
{
    public class EpisodeService: IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public async Task Add(SaveEpisodeViewModel vm)
        {
            Episode episode = new();
            episode.Name = vm.Name;
            episode.Description = vm.Description;
            episode.imagePath = vm.imagePath;
            episode.ReleaseDate = vm.ReleaseDate;
            episode.Season = vm.Season;

            await _episodeRepository.AssAsync(episode);
        }
        public async Task Update(SaveEpisodeViewModel vm)
        {
            Episode episode = new();
            episode.Name = vm.Name;
            episode.Description = vm.Description;
            episode.imagePath = vm.imagePath;
            episode.ReleaseDate = vm.ReleaseDate;
            episode.Season = vm.Season;

            await _episodeRepository.UpdateAsync(episode);
        }
        public async Task Delete(int id)
        {
            var episode = await _episodeRepository.GetByIdAsync(id);
            await _episodeRepository.DeleteAsync(episode);
        }

        public async Task<SaveEpisodeViewModel> GetByIdSaveViewModel(int id)
        {
            var episode = await _episodeRepository.GetByIdAsync(id);

            SaveEpisodeViewModel vm = new();
            vm.Name = episode.Name;
            vm.Description = episode.Description;
            vm.imagePath = episode.imagePath;
            vm.ReleaseDate = episode.ReleaseDate;
            vm.Season = episode.Season;

            return vm;
        }

        public async Task<List<EpisodeViewModel>> GetAllViewModel()
        {
            var episodeList = await _episodeRepository.GetAllAsync();

            return episodeList.Select(episode => new EpisodeViewModel
            {
                Name = episode.Name,
                Description = episode.Description,
                imagePath = episode.imagePath,
                ReleaseDate = episode.ReleaseDate,
                Season = episode.Season


            }).ToList();
        }
    }
}
