using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;  // para poder usar las clases en models, que estan agrupadas en tl2_tp10_2023_GuilloValle.Models
namespace tl2_tp10_2023_GuilloValle.ViewModels;  // Para agrupar los view models en un solo espacio de trabajo

    public class UsuarioViewModel  //Esta clase sirve para pasar de la clase Usuario a la clase UsuarioViewModel para luego mandarla a las vistas
    {
        private rol rolUsuario;
        private string? nombre_de_usuario;
        private int id_usuario;
        private string? Password {get;set;}


        public rol RolUsuario { get => rolUsuario; set => rolUsuario = value; }
        public string? Nombre_de_usuario { get => nombre_de_usuario; set => nombre_de_usuario = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }

        public UsuarioViewModel(Usuario usuario)
        {
            Id_usuario = usuario.Id;
            RolUsuario = usuario.Rol;
            Nombre_de_usuario = usuario.NombreDeUsuario;
        }
        public UsuarioViewModel()
        {
        }
    }
