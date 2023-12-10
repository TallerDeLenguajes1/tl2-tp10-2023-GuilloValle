using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.ViewModels;

    public class CrearTareaViewModel
    {
        public int idTarea{get;set;}
        public int idTablero{get;set;}
        public string? Nombre{get;set;}
        public Estado Estado{get;set;}
        public string? Descripcion{get;set;}
        public string? Color{get;set;}

        public int idUsuarioAsingnado{get:set;}
    }