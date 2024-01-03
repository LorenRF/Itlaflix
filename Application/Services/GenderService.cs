using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.gender;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Services
{
    public class GenderService: IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task Add(SaveGenderViewModel vm)
        {
            Gender gender = new();
            gender.Name = vm.Name;
           

            await _genderRepository.AssAsync(gender);
        }
        public async Task Update(SaveGenderViewModel vm)
        {
            Gender gender = new();
            gender.Name = vm.Name;

            await _genderRepository.UpdateAsync(gender);
        }
        public async Task Delete(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);
            await _genderRepository.DeleteAsync(gender);
        }

        public async Task<SaveGenderViewModel> GetByIdSaveViewModel(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);

            SaveGenderViewModel vm = new();
            vm.Name = gender.Name;

            return vm;
        }

        public async Task<List<GenderViewModel>> GetAllViewModel()
        {
            var genderList = await _genderRepository.GetAllAsync();

            return genderList.Select(gender => new GenderViewModel
            {
                Name = gender.Name,
                SerieGenders = gender.SerieGenders,
                MovieGenders = gender.MovieGenders

            }).ToList();
        }
    }
}
