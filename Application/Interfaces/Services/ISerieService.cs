using Itlaflix.Core.Application.ViewModel.serie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Core.Application.Interfaces.Services
{
    // La interfaz ISerieService se define como una interfaz específica para servicios relacionados con series.
    public interface ISerieService : IGenericService<SaveSerieViewModel, SerieViewModel>
    {
        // Esta interfaz hereda de la interfaz genérica IGenericService, lo que significa que
        // también proporciona métodos para agregar, actualizar, eliminar y obtener series.

        // SaveSerieViewModel se utiliza para representar los datos necesarios para agregar o editar una serie.
        // Contiene propiedades como Name, Description, Gender, image, year, director y Producer,
        // que son necesarias para crear o actualizar una serie en la base de datos.

        // SerieViewModel se utiliza para representar una vista simplificada de una serie.
        // Contiene propiedades como Id, Name, Description, Gender, image, year, director y Producer,
        // que son útiles para mostrar información de series en la interfaz de usuario.

        // Al usar SaveSerieViewModel en los métodos de ISerieService, podemos separar claramente
        // los datos necesarios para la entrada del usuario (agregar o editar una serie) de los datos
        // utilizados para presentar información (mostrar detalles de una serie).

        // Esta separación ayuda a mantener un diseño más limpio y modular, facilitando la expansión y mantenimiento del código.
    }
}
