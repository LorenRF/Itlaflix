using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Application.ViewModel.producer;
using Itlaflix.Core.Domain.Entities;

namespace Itlaflix.Core.Application.Services
{
    public class ProducerService: IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public async Task Add(SaveProducerViewModel vm)
        {
            Producer producer = new();
            producer.Name = vm.Name;

            await _producerRepository.AssAsync(producer);
        }
        public async Task Update(SaveProducerViewModel vm)
        {
            Producer producer = new();
            producer.Name = vm.Name;

            await _producerRepository.UpdateAsync(producer);
        }
        public async Task Delete(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            await _producerRepository.DeleteAsync(producer);
        }

        public async Task<SaveProducerViewModel> GetByIdSaveViewModel(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);

            SaveProducerViewModel vm = new();
            vm.Name = producer.Name;

            return vm;
        }

        public async Task<List<ProducerViewModel>> GetAllViewModel()
        {
            var producerList = await _producerRepository.GetAllAsync();

            return producerList.Select(producer => new ProducerViewModel
            {
                Name = producer.Name,
                ProducerSeries = producer.ProducerSeries,
                ProducerMovies = producer.ProducerMovies

            }).ToList();
        }
    }
}
