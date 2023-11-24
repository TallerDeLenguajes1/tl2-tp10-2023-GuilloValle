using tl2_tp10_2023_GuilloValle.Models;

public interface ItareaRepository
{
    public List<Tarea> GetAllTareasDeUnUsuario(int idUsuario);
    public List<Tarea> GetAllTareasDeUnTablero(int idTablero);
    /*public Tarea ObtenerTareaPorId(int id);
    public Tarea CrearNuevaTareaEnTablero(int idTablero);
    public void EliminarTarea(int id);
    public void ModificarTarea(int id,Tarea Tarea);
    public void AsignarTareaAUsuario(int idTarea,int idUsuario);*/
}