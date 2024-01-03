using Itlaflix.Core.Application.Interfaces.Repositories;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Itlaflix.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceIntefrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));

            }
            else
            {
                services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ISerieRepository, SerieRepository>();
            services.AddTransient<IMovieRepository, MoviesRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<IEpisodeRepository, EpisodesRepository>();




            #endregion
        }

    }
}
