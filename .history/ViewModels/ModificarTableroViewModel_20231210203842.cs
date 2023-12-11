using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ModificarTableroViewModel
    {   
        public int Id{get;set;}

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Id del propietario del tablero")]
        public int IdPropietario{get;set;}
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre del tablero")]
        public string Nombre{get;set;}

        public string Descripcion{get;set;}



        public ModificarTableroViewModel(){

        }

        public ModificarTableroViewModel(Tablero tablero){

            Id = tablero.Id;
            IdPropietario = tablero.Id_propietario;
            Nombre = tablero.Nombre;
            Descripcion = tablero.Descripcion;
        }
    }
