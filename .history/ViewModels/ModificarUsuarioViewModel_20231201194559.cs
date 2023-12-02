using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class ModificarUsuarioViewModel
    {
        private string? nombre_de_usuario;
        private string? pass;
        private rol rolUsuario;
        private int id_usuario;

        public ModificarUsuarioViewModel()
        {
        }

        public ModificarUsuarioViewModel(Usuario usuario)
        {
            Nombre_de_usuario = usuario.NombreDeUsuario;
            Pass = usuario.Password;
            RolUsuario = usuario.Rol;
            Id_usuario = usuario.Id;
        }
        
        //[Required(ErrorMessage = "Este campo es requerido.")]
        //[Display(Name = "Nombre De Usuario")]
        public string? Nombre_de_usuario { get => nombre_de_usuario; set => nombre_de_usuario = value; }
        
        //[Required(ErrorMessage = "Este campo es requerido.")]
        //[Display(Name = "Contraseña")]
        public string? Pass { get => pass; set => pass = value; }

        //[Required(ErrorMessage = "Este campo es requerido.")]
        //[Display(Name = "Rol")]
        public Rol RolUsuario { get => rolUsuario; set => rolUsuario = value; }
        
        //[Required(ErrorMessage = "Este campo es requerido.")]
        //[Display(Name = "Id_Usuario")]
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
    }
