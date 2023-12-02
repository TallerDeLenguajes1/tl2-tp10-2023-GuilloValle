using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class TareaViewModel
    {
        private int id_tarea;
        private string? nombre;
        private estado estado;
        private string? descripcion;
        private string? color;

        public TareaViewModel()
        {
        }

        public TareaViewModel(Tarea tarea)
        {
            Id_tarea = tarea.Id;
            Nombre = tarea.Nombre;
            Descripcion = tarea.Descripcion;
            Color = tarea.Color;
            Estado = tarea.Estado;
        }

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public string? Color { get => color; set => color = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public int Id_tarea { get => id_tarea; set => id_tarea = value; }
    }
