using tl2_tp10_2023_GuilloValle.Models;
namespace ConjuntoDeInterfacesRepo;
public interface ITareaRepository
{
    public List<Tarea> GetAllTareasDeUnUsuario(int idUsuario);
    public List<Tarea> GetAllTareasDeUnUsuario1(int idUsuario);
    public List<Tarea> GetAllTareasDeUnTablero(int idTablero);
    public Tarea GetTareaById(int id);

    
    /*public Tarea CrearNuevaTareaEnTablero(int idTablero);*/
    public void EliminarTarea(int id);
    public void ModificarTarea(Tarea Tarea);
    /*public void AsignarTareaAUsuario(int idTarea,int idUsuario);*/
}