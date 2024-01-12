using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.episode;
using Itlaflix.Core.Domain.Entities;
using System.Xml.Linq;
using System;
using Itlaflix.Core.Application.ViewModel.movie;
using Itlaflix.Core.Application.ViewModel.season;

namespace Itlaflix.Core.Application.Services
{
    public class EpisodeService: IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly ISeasonRepository _seasonRepository;


        public EpisodeService(IEpisodeRepository episodeRepository, ISeasonRepository seasonRepository)
        {
            _episodeRepository = episodeRepository;
            _seasonRepository = seasonRepository;
        }

        public async Task Add(SaveEpisodeViewModel vm)
        {
            vm.Season = await _seasonRepository.GetByIdAsync(vm.SeasonId);


            Episode episode = new();
            episode.Name = vm.Name;
            episode.Description = vm.Description;
            episode.imagePath = vm.imagePath;
            episode.ReleaseDate = vm.ReleaseDate;
            episode.Season = vm.Season;
            episode.SeasonId = vm.SeasonId;
            episode.url = vm.url;
            episode.episodeNumber = vm.episodeNumber;

            await _episodeRepository.AssAsync(episode);
        }
        public async Task Update(SaveEpisodeViewModel vm)
        {
            Episode episode = await _episodeRepository.GetByIdAsync(vm.Id);
            vm.Season = await _seasonRepository.GetByIdAsync(vm.SeasonId);
            episode.Name = vm.Name;
            episode.Description = vm.Description;
            episode.imagePath = vm.imagePath;
            episode.ReleaseDate = vm.ReleaseDate;
            episode.Season = vm.Season;
            episode.SeasonId = vm.SeasonId;
            episode.url = vm.url;
            episode.episodeNumber = vm.episodeNumber;


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
            vm.Season = await _seasonRepository.GetByIdAsync(episode.SeasonId); ;
            vm.SeasonId = episode.SeasonId;
            vm.url = episode.url;
            vm.Id = episode.Id;
            vm.episodeNumber = episode.episodeNumber;

            return vm;
        }

        public async Task<EpisodeViewModel> GetByIdViewModel(int id)
        {
            var episode = await _episodeRepository.GetByIdAsync(id);
           
            EpisodeViewModel vm = new();
            vm.Name = episode.Name;
            vm.Description = episode.Description;
            vm.imagePath = episode.imagePath;
            vm.ReleaseDate = episode.ReleaseDate;
            vm.Season = await _seasonRepository.GetByIdAsync(episode.SeasonId); ;
            vm.SeasonId = episode.SeasonId;
            vm.url = episode.url;
            vm.Id = episode.Id;

            return vm;
        }

        public async Task<List<Episode>> GetAllEpisodes()
        {
            var episodes =await _episodeRepository.GetAllAsync();
            foreach(Episode episode in episodes)
            {
                episode.Season = await _seasonRepository.GetByIdAsync(episode.SeasonId);
            }

            episodes.OrderByDescending(e => e.episodeNumber).ToList();

            return episodes;
        }

        public async Task<List<Episode>> GetSeasonEpisodes(int seasonID)
        {
            var episodes = await _episodeRepository.GetAllAsync();
            foreach (Episode episode in episodes)
            {
                episode.Season = await _seasonRepository.GetByIdAsync(episode.SeasonId);
            }

            var seasonEpisode = episodes.Where(e => e.SeasonId == seasonID).ToList();

            seasonEpisode.OrderByDescending(e => e.episodeNumber).ToList();

            return seasonEpisode;
        }


        public async Task<List<EpisodeViewModel>> GetAllViewModel()
        {
            var episodeList = await _episodeRepository.GetAllAsync();

            List<Episode> EpisodesWithSeasonsList = new List<Episode>();

            foreach(Episode evm in episodeList)
            {
                Episode episodes = new Episode();
                episodes.Name = evm.Name;
                episodes.Description = evm.Description;
                episodes.imagePath = evm.imagePath;
                episodes.ReleaseDate = evm.ReleaseDate;
                episodes.Season = await _seasonRepository.GetByIdAsync(evm.SeasonId);
                episodes.SeasonId = evm.SeasonId;
                episodes.url = evm.url;
                episodes.Id = evm.Id;
                episodes.episodeNumber = evm.episodeNumber;

                EpisodesWithSeasonsList.Add(episodes);
            }

            return EpisodesWithSeasonsList.Select(episode => new EpisodeViewModel
            {
                Name = episode.Name,
                Description = episode.Description,
                imagePath = episode.imagePath,
                ReleaseDate = episode.ReleaseDate,
                Season = episode.Season,
                SeasonId = episode.SeasonId,
                url = episode.url,
                Id = episode.Id,
                episodeNumber = episode.episodeNumber


            }).ToList();
        }
    }
}
