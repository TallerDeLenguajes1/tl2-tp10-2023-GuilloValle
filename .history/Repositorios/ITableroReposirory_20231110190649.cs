using tl2_tp10_2023_GuilloValle.Models;

public interface ITableroReposirory
{
    public List<Tablero> GetAllTableros();

    public void CrearNuevoTablero(Tablero tablero);

   /* public void ModificarTablero(int id,Tablero tablero);*/

    /*public Tablero ObtenerTableroPorId(int id);*/

   /* public List<Tablero> GetAllTablerosDeUsuarioEspecifico(int idUsuario);*/

   /* public void EliminarTablero(int id);*/
}