// Clase SaveSerieViewModel utilizada para la creación y edición de series desde la vista.
using Itlaflix.Core.Application.ViewModel.director;
using Itlaflix.Core.Application.ViewModel.gender;
using Itlaflix.Core.Application.ViewModel.productor;
using Itlaflix.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class SaveSerieViewModel
{
    // Identificador único de la serie.
    public int Id { get; set; }

    // Nombre de la serie, es un campo obligatorio.
    [Required(ErrorMessage = "Debe colocar el nombre de la serie")]
    public string Name { get; set; }

    // Descripción de la serie.
    public string Description { get; set; }

    // Géneros asociados a la serie, es un campo obligatorio.
    [Required(ErrorMessage = "Debe colocar el genero de la serie")]
    public ICollection<SerieGender> Gender { get; set; }

    // Ruta de la imagen de la serie.
    public string image { get; set; }

    // Año de lanzamiento de la serie, es un campo obligatorio.
    [Required(ErrorMessage = "Debe colocar el año de la serie")]
    public int year { get; set; }

    // Director de la serie, es un campo obligatorio.
    [Required(ErrorMessage = "Debe colocar el director de la serie")]
    public Director director { get; set; }

    // Productores asociados a la serie, es un campo obligatorio.
    [Required(ErrorMessage = "Debe colocar el productor de la serie")]
    public ICollection<ProducerSerie> producer { get; set; }

    // Lista de productores disponibles en la base de datos.
    public List<ProducerViewModel> producerList { get; set; }

    // Lista de directores disponibles en la base de datos.
    public List<DirectorViewModel> directorList { get; set; }

    // Lista de géneros disponibles en la base de datos.
    public List<GenderViewModel> genderList { get; set; }
}
