using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class TareaViewModel
    {
        private int id_tarea;
        private int id_Tablero;
        private string? nombre;
        private Estado estado;
        private string? descripcion;
        private string? color;

        private int id_Usuario_Asingnado;

        public TareaViewModel()
        {
        }

        public TareaViewModel(Tarea tarea)
        {
            Id_tarea = tarea.Id;
            id_Tablero = tarea.IdTablero;
            Nombre = tarea.Nombre;
            Descripcion = tarea.Descripcion;
            Color = tarea.Color;
            Estado = tarea.Estado;
            id_Usuario_Asingnado = tarea.IdUsuarioAsingnado;
        }

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public string? Color { get => color; set => color = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public int Id_tarea { get => id_tarea; set => id_tarea = value; }
        public int Id_Tablero { get => id_Tablero; set => id_Tablero = value; }
        public int Id_Usuario_Asingnado { get => id_Usuario_Asingnado; set => id_Usuario_Asingnado = value; }
}
