using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class TableroViewModel
    {
        private int id_tablero;
        private int id_usuario_propietario;
        private string? nombre;
        private string? descripcion;

        public TableroViewModel()
        {
        }

        public TableroViewModel(Tablero tablero)
        {
            Id_usuario_propietario = tablero.Id_usuario_propietario;
            Nombre = tablero.Nombre;
            Descripcion = tablero.Descripcion;
            Id_tablero = tablero.Id_tablero;
        }

        public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    }
