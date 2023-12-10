using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ModificarTableroViewModel
    {   
        public int Id;
        public int IdTablero;
        public string Nombre;
        public Estado Estado;
        public string Descripcion;
        public string Color;
        public int IdUsuarioAsingnado;



        public ModificarTableroViewModel(){

        }

        public ModificarTableroViewModel(Tablero tablero){

            Id = tablero.Id;
            IdPropietario = tablero.Id_propietario;
            Nombre = tablero.Nombre;
            Descripcion = tablero.Descripcion;
        }
    }
