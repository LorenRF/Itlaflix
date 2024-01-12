using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel.episode;
using Itlaflix.Core.Application.ViewModel.season;
using Itlaflix.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Itlaflix.Core.Application.Services
{
    public class SeasonService: ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly ISerieRepository _serieRepository;
        private readonly IEpisodeService _episodeService;


        public SeasonService(ISeasonRepository seasonRepository, ISerieRepository serieRepository
            , IEpisodeService episodeService)
        {
            _seasonRepository = seasonRepository;
            _serieRepository = serieRepository;
            _episodeService = episodeService;
        }

        public async Task Add(SaveSeasonViewModel vm)
        {
            vm.Serie = await _serieRepository.GetByIdAsync(vm.SerieId);
            
            Season season = new();
            season.SeasonNumber = vm.SeasonNumber;
            season.Serie = vm.Serie;
            season.SerieId = vm.SerieId;

            await _seasonRepository.AssAsync(season);
        }
        public async Task Update(SaveSeasonViewModel vm)
        {
            Season season = await _seasonRepository.GetByIdAsync(vm.Id);
            season.Serie = await _serieRepository.GetByIdAsync(vm.SerieId);
            season.SeasonNumber = vm.SeasonNumber;
            season.Serie = vm.Serie;            
            season.SerieId = vm.SerieId;

            await _seasonRepository.UpdateAsync(season);
        }
        public async Task Delete(int id)
        {
            var season = await _seasonRepository.GetByIdAsync(id);
            await _seasonRepository.DeleteAsync(season);
        }

        public async Task<SaveSeasonViewModel> GetByIdSaveViewModel(int id)
        {
            var season = await _seasonRepository.GetByIdAsync(id);
            season.Serie = await _serieRepository.GetByIdAsync(season.SerieId);

            SaveSeasonViewModel vm = new();
            vm.SeasonNumber = season.SeasonNumber;
            vm.Serie = season.Serie;
            vm.SerieId = season.SerieId;
            vm.Id = season.Id;

            return vm;
        }

        public async Task<List<SeasonViewModel>> GetAllViewModel()
        {
            var seasonList = await _seasonRepository.GetAllWithIncludeAsync(new List<string> { "Episodes" });

            var seasonViewModels = new List<SeasonViewModel>();

            foreach (var season in seasonList)
            {
                var serie = await _serieRepository.GetByIdAsync(season.SerieId);

                var seasonViewModel = new SeasonViewModel
                {
                    SeasonNumber = season.SeasonNumber,
                    Serie = serie,
                    SerieId = season.SerieId,
                    Id = season.Id,
                    Episodes = season.Episodes
            };

                seasonViewModels.Add(seasonViewModel);
            }



            return seasonViewModels;
        }

        public async Task<SeasonViewModel> GetByIdViewModel(int id)
        {
            var season = await _seasonRepository.GetByIdAsync(id);
            season.Serie = await _serieRepository.GetByIdAsync(season.SerieId);

            SeasonViewModel vm = new();
            vm.SeasonNumber = season.SeasonNumber;
            vm.Serie = season.Serie;
            vm.SerieId = season.SerieId;
            vm.Episodes = await _episodeService.GetAllEpisodes();
            vm.Id = season.Id;

            return vm;
        }


        public async Task<List<EpisodeViewModel>> GetAllEpisodes(int id)
        {
            var episodeList = await _episodeService.GetAllViewModel();

            // Filtra los episodios por SeasonId
            var filteredEpisodes = episodeList.Where(e => e.SeasonId == id).ToList();


            return filteredEpisodes;


        }


    }
}
