using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class CrearUsuarioViewModel
    {
        public int Id{get;set;}

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre De Usuario")]
        public string Nombre_de_usuario{get;set;}

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Contraseña")]
        public string   Contrasenia{get;set;}

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Rol")]
        public Rol RolUsuario{get;set;}

        
}
