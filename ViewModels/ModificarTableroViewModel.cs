using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ModificarTableroViewModel
    {
        public int IdPropietario{get;set;}
        
        public string Nombre{get;set;}

        public string Descripcion{get;set;}

        public ModificarTableroViewModel(){

        }

        public ModificarTableroViewModel(Tablero tablero){

            IdPropietario = tablero.Id_propietario;
            Nombre = tablero.Nombre;
            Descripcion = tablero.Descripcion;
        }
    }
