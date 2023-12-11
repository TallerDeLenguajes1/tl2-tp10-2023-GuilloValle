using tl2_tp10_2023_GuilloValle.Models;
namespace ConjuntoDeInterfacesRepo;

public interface ITableroRepository
{
    public List<Tablero> GetAllTableros();

    public void CrearNuevoTablero(Tablero tablero);

    public void ModificarTablero(Tablero tablero);

    public Tablero GetTableroById(int id);

    public List<Tablero> GetTableroByIdPropietario(int id_propietario);

   /* public List<Tablero> GetAllTablerosDeUsuarioEspecifico(int idUsuario);*/

    public void EliminarTablero(int id);
}