using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    
    public class ListarTareasViewModel
    {
        
        public List<TareaViewModel> ListarTareasVM {get;set;}
        public ListarTareasViewModel(List<Tarea> tareas)
        {
            ListarTareasVM = new List<TareaViewModel>(); 
            foreach (var tar in tareas)
            {
                var TareaVM = new TareaViewModel(tar);
                ListarTareasVM.Add(TareaVM);
            }
        }

        public ListarTareasViewModel(Tarea tarea){
            
            ListarTareasVM = new List<TareaViewModel>();
            var TareaViewM = new TareaViewModel(tarea);
            ListarTareasVM.Add(TareaViewM);
        }
    }
