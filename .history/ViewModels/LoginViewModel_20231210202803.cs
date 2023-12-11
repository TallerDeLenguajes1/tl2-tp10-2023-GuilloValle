using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre de Usuario")] 
        public string Nombre {get;set;}        
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [DataType(DataType.Password)] // Esta anotación indica que la propiedad es una contraseña y la oculta cuando tipeo
        [Display(Name = "Contraseña")]
        public string Contrasenia {get;set;}
    }
