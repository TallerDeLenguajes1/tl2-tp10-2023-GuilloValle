using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;


    public class ListarTableroViewModel
    {
        
        public List<TableroViewModel> ListarTableroVM {get;set;}
        public ListarTableroViewModel(List<Tablero> tableros)
        {
            ListarTableroVM = new List<TableroViewModel>(); 
            foreach (var tabl in tableros)
            {
                var TableroVM = new TableroViewModel(tabl);
                ListarTableroVM.Add(TableroVM);
            }
        }

        public ListarTableroViewModel(Tablero tablero){
            
            ListarTableroVM = new List<TableroViewModel>();
            var UsuarioViewM = new TableroViewModel(tablero);
            ListarTableroVM.Add(UsuarioViewM);
        }
    }
