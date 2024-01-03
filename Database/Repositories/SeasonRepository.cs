using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Domain.Entities;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Itlaflix.Infrastructure.Persistence.Repositories
{
    public class SeasonRepository : GenericRepository<Season>, ISeasonRepository
    {
        private readonly ApplicationContext dbcontext;
        public SeasonRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            dbcontext = applicationContext;
        }
    }
}
