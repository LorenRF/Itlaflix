using Itlaflix.Core.Application.Services;
using Itlaflix.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Interfaces.Repositories
{
    // Interfaz para el repositorio de la entidad Serie.
    public interface IProducerMovieRepository : IGenericRepository<ProducerMovie>
    {
        // No se añaden nuevos métodos aquí, ya que esta interfaz utiliza la funcionalidad proporcionada por IGenericRepository.
        // Se podría agregar métodos específicos de Serie si es necesario en el futuro.
    }
}
