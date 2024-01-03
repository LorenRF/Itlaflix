using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.season;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Services
{
    public class SeasonService: ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task Add(SaveSeasonViewModel vm)
        {
            Season season = new();
            season.SeasonNumber = vm.SeasonNumber;
            season.Serie = vm.Serie;

            await _seasonRepository.AssAsync(season);
        }
        public async Task Update(SaveSeasonViewModel vm)
        {
            Season season = new();
            season.SeasonNumber = vm.SeasonNumber;
            season.Serie = vm.Serie;

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

            SaveSeasonViewModel vm = new();
            vm.SeasonNumber = season.SeasonNumber;
            vm.Serie = season.Serie;

            return vm;
        }

        public async Task<List<SeasonViewModel>> GetAllViewModel()
        {
            var seasonList = await _seasonRepository.GetAllAsync();

            return seasonList.Select(season => new SeasonViewModel
            {
                SeasonNumber = season.SeasonNumber,
                Serie = season.Serie

            }).ToList();
        }
    }
}
