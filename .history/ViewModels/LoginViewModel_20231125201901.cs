using System.ComponentModel;

namespace tl2_tp10_2023_GuilloValle.ViewModels;

public class LoginViewModel
{
    private string? nombreUsuario;
    private string? contraseniaUsuario;
    
    // [Required(ErrorMessage = "Este campo es requerido")]
    // [Display(Name = "Nombre de usuario")]
    public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    
    // [Required(ErrorMessage = "Este campo es requerido")]
    // [Display(Name = "Contraseña")]
    public string ContraseniaUsuario { get => contraseniaUsuario; set => contraseniaUsuario = value; }
}