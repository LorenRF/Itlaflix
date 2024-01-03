using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Domain.Entities;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Itlaflix.Infrastructure.Persistence.Repositories
{
    public class EpisodesRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        private readonly ApplicationContext dbcontext;
        public EpisodesRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            dbcontext = applicationContext;
        }
    }
}
