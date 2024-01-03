using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Domain.Entities;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Itlaflix.Infrastructure.Persistence.Repositories
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        private readonly ApplicationContext dbcontext;
        public ProducerRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            dbcontext = applicationContext;
        }
    }
}
