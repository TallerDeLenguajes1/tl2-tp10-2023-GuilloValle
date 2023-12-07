using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ListarUsuariosViewModel
    {
        public List<UsuarioViewModel> ListarUsariosVM {get;set;}
        public ListarUsuariosViewModel(List<Usuario> usuarios)
        {
            ListarUsariosVM = new List<UsuarioViewModel>(); //Hay que instarnsiarlo por mas que este como atributo de la clase?
            foreach (var usuario in usuarios)
            {
                var UsuarioViewM = new UsuarioViewModel(usuario);
                ListarUsariosVM.Add(UsuarioViewM);
            }
        }

        public ListarUsuariosViewModel(Usuario usuario){
            
            ListarUsariosVM = new List<UsuarioViewModel>();
            var UsuarioViewM = new UsuarioViewModel(usuario);
            ListarUsariosVM.Add(UsuarioViewM);
        }

        
       
    }
