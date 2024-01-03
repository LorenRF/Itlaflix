// Clase estática ServiceRegistration en la capa de aplicación para registrar servicios en el contenedor de dependencias.
using Itlaflix.Core.Application.Interfaces.Services;
using Itlaflix.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Itlaflix.Core.Application
{
    public static class ServiceRegistration
    {
        // Método de extensión para IServiceCollection que registra servicios de la capa de aplicación.
        // esta clase luego se usa en el program para la inyeccion de dependencias
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region services

            // Registro de servicios para cada entidad o funcionalidad en el sistema.

            // Servicio para operaciones relacionadas con series.
            services.AddTransient<ISerieService, SerieService>();

            // Servicio para operaciones relacionadas con directores.
            services.AddTransient<IDirectorService, DirectorService>();

            // Servicio para operaciones relacionadas con episodios.
            services.AddTransient<IEpisodeService, EpisodeService>();

            // Servicio para operaciones relacionadas con géneros.
            services.AddTransient<IGenderService, GenderService>();

            // Servicio para operaciones relacionadas con películas.
            services.AddTransient<IMovieService, MovieService>();

            // Servicio para operaciones relacionadas con productores.
            services.AddTransient<IProducerService, ProducerService>();

            // Servicio para operaciones relacionadas con temporadas.
            services.AddTransient<ISeasonService, SeasonService>();

            #endregion
        }
    }
}
