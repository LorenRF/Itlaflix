using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Interfaces.Repositories
{
    // Interfaz para un repositorio genérico que define operaciones comunes para cualquier entidad.
    public interface IGenericRepository<Entity> where Entity : class
    {
        // Método asincrónico para agregar una entidad a la base de datos.
        Task AssAsync(Entity entity);

        // Método asincrónico para actualizar una entidad en la base de datos.
        Task UpdateAsync(Entity entity);

        // Método asincrónico para eliminar una entidad de la base de datos.
        Task DeleteAsync(Entity entity);

        // Método asincrónico para obtener todas las entidades de la base de datos.
        Task<List<Entity>> GetAllAsync();
        // Método asincrónico para obtener todas las entidades de la base de datos incluyendo a las relaciones de estas.
        Task<List<Entity>> GetAllWithIncludeAsync(List<string> propierties);

        // Método asincrónico para obtener una entidad por su identificador.
        Task<Entity> GetByIdAsync(int id);
    }
}
