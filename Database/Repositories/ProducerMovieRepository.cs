// Clase SerieRepository
// Esta clase extiende GenericRepository<Serie> e implementa la interfaz ISerieRepository, proporcionando operaciones específicas para la entidad Serie en el contexto de la base de datos.

using Itlaflix.Core.Application.Interfaces.Repositories;  // Importa la interfaz ISerieRepository
using Itlaflix.Core.Application.ViewModel;                // Importa modelos de vista
using Itlaflix.Core.Domain.Entities;                     // Importa la entidad Serie
using Itlaflix.Infrastructure.Persistence.Contexts;       // Importa el contexto de la base de datos
using Microsoft.EntityFrameworkCore;                     // Importa clases de Entity Framework Core

namespace Itlaflix.Infrastructure.Persistence.Repositories
{
    // La clase SerieRepository hereda de GenericRepository<Serie> e implementa la interfaz ISerieRepository.
    public class ProducerMovieRepository : GenericRepository<ProducerMovie>, IProducerMovieRepository
    {
        // DbContext para interactuar con la base de datos
        private readonly ApplicationContext dbcontext;

        // Constructor que recibe el contexto de la base de datos como dependencia y lo pasa al constructor de la clase base
        public ProducerMovieRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            dbcontext = applicationContext;
        }
    }
}
