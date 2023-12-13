using Itlaflix.Core.Application.Repositories;
using Itlaflix.Core.Application.ViewModel;
using Itlaflix.Core.Domain.Entities;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Infrastructure.Persistence.Repositories
{
    public sealed class SeriesRepository : ISerieRepository
    {
        private readonly ApplicationContext dbcontext;
        public SeriesRepository(ApplicationContext applicationContext) 
        {
            dbcontext = applicationContext;
        }
        //public static SeriesRepository Instance { get; } = new SeriesRepository();
        public EntitiesListViewModel EntitiesListViewModel { get; set; }    = new EntitiesListViewModel();
  
        public async Task AddAsync(Serie serie)
        {
            await dbcontext.Series.AddAsync(serie);
            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Serie serie)
        {
            dbcontext.Entry(serie).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
        }

        public async Task RemuveAsync(Serie serie)
        {
            dbcontext.Set<Serie>().Remove(serie);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<List<Serie>> GetSeries()
        {
            return await dbcontext.Set<Serie>().ToListAsync();
        }

        public async Task<Serie> GetSeriebyID(int id)
        {
            return await dbcontext.Set<Serie>().FindAsync(id);
        }

    }
}
