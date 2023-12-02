namespace tl2_tp10_2023_GuilloValle.Models;

public enum Estado{

    ideas,
    ToDo,
    Doing,
    Review,
    Done
}
public class Tarea
{
    private int id;
    private int idTablero;
    private string nombre;
    private Estado estado;
    private string descripcion;
    private string color;
    private int idUsuarioAsingnado;

    public int Id { get => id; set => id = value; }
    public int IdTablero { get => idTablero; set => idTablero = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Color { get => color; set => color = value; }
    public int IdUsuarioAsingnado { get => idUsuarioAsingnado; set => idUsuarioAsingnado = value; }
    public Estado Estado { get => estado; set => estado = value; }
}