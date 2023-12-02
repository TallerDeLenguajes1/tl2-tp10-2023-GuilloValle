using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using tl2_tp10_2023_GuilloValle.Models;
using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Controllers;



    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private IUsuarioRepository usuarioRepository;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            usuarioRepository = new UsuarioRepository();
 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }


        [HttpPost] // AQUI VIENE EL LOGIN DEL FORM
        public IActionResult Login(LoginViewModel usuarioLogueado)
    {
        var user = usuarioRepository.GetAllUsuarios().FirstOrDefault(u => u.NombreDeUsuario == usuarioLogueado.Nombre && u.Password == usuarioLogueado.Pass);
        if(user == null) return RedirectToAction("Index");
        LoguearUsuario(user);

        return RedirectToRoute(new{controller = "Home", action = "Index"});

    }


     private void LoguearUsuario(Usuario usuario){
        HttpContext.Session.SetString("id", usuario.Id.ToString());
        HttpContext.Session.SetString("usuario", usuario.NombreDeUsuario);
        HttpContext.Session.SetString("rol", usuario.Rol.ToString());
    }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
