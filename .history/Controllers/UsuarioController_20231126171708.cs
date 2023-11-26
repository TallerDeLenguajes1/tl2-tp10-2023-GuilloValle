﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Controllers;


public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;

    private UsuarioRepository usuarioRepository;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    public IActionResult Index()
    {   
        var Usuarios = usuarioRepository.GetAllUsuarios();
        var UsuarioVM = new ListarUsuariosViewModel(Usuarios);
        return View(UsuarioVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CrearUsuario()
    {   
        
        return View(new CrearUsuarioViewModel());
    }

    [HttpPost]
    public IActionResult CrearUsuario(CrearUsuarioViewModel usuarioCVM)
    {   
        var nuevoUsuario = new Usuario(usuarioCVM);
        usuarioRepository.CrearNuevoUsuario(nuevoUsuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult ModificarUsuario(int idUsuario)
    {   
        var Usuario = usuarioRepository.ObtenerUsuarioPorId(idUsuario); //Busco el usuario a modificar
        var UsuMVM = new ModificarUsuarioViewModel(Usuario);            //Lo convierto a usuario de la clase usuario a la clase VM modificar uusario
        return View(usuarioAMod);                                       //Le mando a la vista el VM de modificar usuario
    }

    [HttpPost]
    public IActionResult ModificarUsuario(Usuario usuarioNuevo)
    {   
        usuarioRepository.ModificarUsuario(usuarioNuevo);
        return RedirectToAction("Index");
    }
    
    public IActionResult EliminarUsuario(int idUsuario)
    {
        usuarioRepository.EliminarUsuario(idUsuario);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
