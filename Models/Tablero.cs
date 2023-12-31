using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Models;

public class Tablero
{
    private int id;
    private int id_propietario;
    private string nombre;
    private string descripcion;

    public int Id { get => id; set => id = value; }
    public int Id_propietario { get => id_propietario; set => id_propietario = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }


    public Tablero(){

    }

    public Tablero(CrearTableroViewModel tableroVM)
    {   
        
        id_propietario = tableroVM.IdPropietario;
        Nombre = tableroVM.Nombre;
        descripcion = tableroVM.Descripcion;
    }

    public Tablero(ModificarTableroViewModel tableroVM)
    {   
        id = tableroVM.Id;
        id_propietario = tableroVM.IdPropietario;
        Nombre = tableroVM.Nombre;
        descripcion = tableroVM.Descripcion;
    }


}