using Itlaflix.Core.Application.ViewModel.episode;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Interfaces.Services
{
    public interface IEpisodeService : IGenericService<SaveEpisodeViewModel, EpisodeViewModel>
    {
        Task<List<Episode>> GetAllEpisodes();
    }
}
