using System.ComponentModel.DataAnnotations;    
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ModificarTareaViewModel
    {
        public int Id{get;set;}
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Id del tablero para la tarea")]

        public int IdTablero{get;set;}

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "nombre del tablero")]
        public string Nombre{get;set;}
        public Estado Estado{get;set;}
        public string Descripcion{get;set;}
        public string Color{get;set;}
        public int IdUsuarioAsingnado{get;set;}


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
