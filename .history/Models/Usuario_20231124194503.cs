namespace tl2_tp10_2023_GuilloValle.Models;

public enum rol
{
    administrador,
    operador
}
public class Usuario
{
    private int id;
    private string nombreDeUsuario;

    public string Password{get;set;}

    public rol Rol{get;set;}

    public int Id { get => id; set => id = value; }
    public string NombreDeUsuario { get => nombreDeUsuario; set => nombreDeUsuario = value; }
}