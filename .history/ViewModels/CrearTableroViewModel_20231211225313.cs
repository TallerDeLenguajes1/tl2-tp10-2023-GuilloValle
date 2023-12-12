using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;



    public class CrearTableroViewModel
    {
        //public int Id{get;set;} 

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Propietario del tablero")]
        public int IdPropietario{get;set;}

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre del tablero")]
        public string Nombre{get;set;}

        public string Descripcion{get;set;}

        public List<Usuario> Usuarios {get;set;}


        public CrearTableroViewModel(){
            
        }
        public CrearTableroViewModel(List<Usuario> usuarios){
            Usuarios = usuarios;
        }


    }
