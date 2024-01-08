using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Domain.Entities;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Itlaflix.Infrastructure.Persistence.Repositories
{
    public class ProducerSerieRepository : GenericRepository<ProducerSerie>, IProducerSerieRepository
    {
        private readonly ApplicationContext dbcontext;
        public ProducerSerieRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            dbcontext = applicationContext;
        }
    }
}
