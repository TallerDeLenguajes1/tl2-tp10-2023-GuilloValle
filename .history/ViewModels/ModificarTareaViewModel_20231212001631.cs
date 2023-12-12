using System.ComponentModel.DataAnnotations;    
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ModificarTareaViewModel
    {
        public int Id;
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Id del tablero para la tarea")]

        public int IdTablero;

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "nombre del tablero")]
        public string Nombre;
        public Estado Estado;
        public string Descripcion;
        public string Color;
        public int IdUsuarioAsingnado;


        public ModificarTareaViewModel(){

        }

    public ModificarTareaViewModel(Tarea tarea)
    {
        Id = tarea.Id;
        IdTablero = tarea.IdTablero;
        Nombre = tarea.Nombre;
        Estado = tarea.Estado;
        Descripcion = tarea.Descripcion;
        Color = tarea.Color;
        IdUsuarioAsingnado = tarea.IdUsuarioAsingnado;
    }
}
