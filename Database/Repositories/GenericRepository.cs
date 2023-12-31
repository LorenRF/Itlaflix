﻿// Clase GenericRepository
// Esta clase implementa la interfaz IGenericRepository y proporciona operaciones CRUD genéricas para cualquier entidad del contexto de base de datos.

using Itlaflix.Core.Application.Interfaces.Repositories;  // Importa la interfaz IGenericRepository
using Itlaflix.Infrastructure.Persistence.Contexts;        // Importa el contexto de la base de datos
using Microsoft.EntityFrameworkCore;                        // Importa clases de Entity Framework Core


namespace Itlaflix.Infrastructure.Persistence.Repositories
{
    // La clase GenericRepository es genérica y acepta cualquier tipo de entidad que herede de class.
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        // DbContext para interactuar con la base de datos
        private readonly ApplicationContext _dbContext;

        // Constructor que recibe el contexto de la base de datos como dependencia
        public GenericRepository(ApplicationContext applicationContext)
        {
            _dbContext = applicationContext;
        }

        // Método para agregar una nueva entidad a la base de datos
        public async Task AssAsync(Entity entity)
        {
            // Agrega la entidad al DbSet del contexto
            await _dbContext.Set<Entity>().AddAsync(entity);

            // Guarda los cambios en la base de datos
            await _dbContext.SaveChangesAsync();
        }

        // Método para actualizar una entidad en la base de datos
        public async Task UpdateAsync(Entity entity)
        {
            // Cambia el estado de la entidad a modificado en el contexto
            _dbContext.Entry(entity).State = EntityState.Modified;

            // Guarda los cambios en la base de datos
            await _dbContext.SaveChangesAsync();
        }

        // Método para eliminar una entidad de la base de datos
        public async Task DeleteAsync(Entity entity)
        {
            // Remueve la entidad del DbSet del contexto
            _dbContext.Set<Entity>().Remove(entity);

            // Guarda los cambios en la base de datos
            await _dbContext.SaveChangesAsync();
        }

        // Método para obtener todas las entidades de un tipo desde la base de datos
        public async Task<List<Entity>> GetAllAsync()
        {
            // Utiliza el DbSet del contexto para obtener todas las entidades y las convierte a una lista
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        // Método para obtener una entidad por su Id desde la base de datos
        public async Task<Entity> GetByIdAsync(int id)
        {
            // Utiliza el DbSet del contexto para encontrar una entidad por su Id
            return await _dbContext.Set<Entity>().FindAsync(id);
        }
    }
}
