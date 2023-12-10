using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ModificarTareaViewModel
    {
        public int Id;
        public int IdTablero;
        public string Nombre;
        public Estado Estado;
        public string Descripcion;
        public string Color;
        public int IdUsuarioAsingnado;



        public ModificarTareaViewModel(){

        }

    public ModificarTareaViewModel(Tarea tarea)
    {
        Id = tarea.Id;
        IdTablero = tarea.IdTablero;
        Nombre = tarea.Nombre;
        Estado = tarea.Estado;
        Descripcion = tarea.Descripcion;
        Color = tarea.Color;
        IdUsuarioAsingnado = tarea.IdUsuarioAsingnado;
    }
}
