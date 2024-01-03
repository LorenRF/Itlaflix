using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Interfaces.Services
{
    // Interfaz genérica para servicios. Las demás interfaces de servicios pueden heredar de esta.
    public interface IGenericService<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        // Método asincrónico para agregar una entidad a la base de datos.
        Task Add(SaveViewModel vm);

        // Método asincrónico para actualizar una entidad en la base de datos.
        Task Update(SaveViewModel vm);

        // Método asincrónico para eliminar una entidad de la base de datos por su identificador.
        Task Delete(int id);

        // Método asincrónico para obtener una entidad y mapearla a un SaveViewModel por su identificador.
        Task<SaveViewModel> GetByIdSaveViewModel(int id);

        // Método asincrónico para obtener todas las entidades y mapearlas a ViewModel.
        Task<List<ViewModel>> GetAllViewModel();
    }
}
