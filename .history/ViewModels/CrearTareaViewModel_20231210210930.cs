using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class CrearTareaViewModel
    {
        public int idTarea{get;set;}
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Id del tablero para la tarea")]
        public int idTablero{get;set;}

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre de la tarea")]
        public string? Nombre{get;set;}

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Estado de la tarea")]
        public Estado Estado{get;set;}
        public string? Descripcion{get;set;}
        public string? Color{get;set;}
        public int idUsuarioAsingnado{get;set;}
        public List<Tablero> tableros{get;set;}
        public List<Usuario> usuarios{get;set;}

        public CrearTareaViewModel(){
            
        }
        public CrearTareaViewModel(List<Tablero> tableros, List<Usuario> usuarios){
            this.tableros = tableros;
            this.usuarios = usuarios;
        }
    }