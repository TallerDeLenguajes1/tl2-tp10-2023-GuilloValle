using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;


    public class ListarTablerViewModel
    {
        
        public List<TableroViewModel> ListarUsariosVM {get;set;}
        public ListarTablerViewModel(List<Tablero> tableros)
        {
            ListarUsariosVM = new List<TableroViewModel>(); //Hay que instarnsiarlo por mas que este como atributo de la clase?
            foreach (var tabl in tableros)
            {
                var TableroVM = new TableroViewModel(tabl);
                ListarUsariosVM.Add(TableroVM);
            }
        }

        public ListarUsuariosViewModel(Usuario usuario){
            
            ListarUsariosVM = new List<UsuarioViewModel>();
            var UsuarioViewM = new UsuarioViewModel(usuario);
            ListarUsariosVM.Add(UsuarioViewM);
        }
    }
