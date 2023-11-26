using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ListarUsuariosViewModel
    {
        private List<UsuarioViewModel> ListarUsariosVM {get;set;}
        public ListarUsuariosViewModel(List<Usuario> usuarios)
        {
            ListarUsariosVM = new List<UsuarioViewModel>();
            foreach (var usuario in usuarios)
            {
                var UsuarioViewM = new UsuarioViewModel(usuario);
                ListarUsariosVM.Add(UsuarioViewM);
            }
        }
       
    }
