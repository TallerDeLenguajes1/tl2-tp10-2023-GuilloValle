using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;



    public class CrearTableroViewModel
    {
        public int Id{get;set;} 
        public int IdPropietario{get;set;}
        
        public string Nombre{get;set;}

        public string Descripcion{get;set;}

        private List<Usuario> Usuarios {get;set;}

        public CrearTableroViewModel(List<Usuario> usuarios){
            Usuarios = usuarios;
        }


    }
