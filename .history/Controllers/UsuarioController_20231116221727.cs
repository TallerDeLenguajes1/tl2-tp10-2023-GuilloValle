using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
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
        return View(Usuarios);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CrearUsuario()
    {   
        return View(new Usuario());
    }

    [HttpPost]
    public IActionResult CrearUsuario(Usuario usuario)
    {   
        var Usuarios = usuarioRepository.GetAllUsuarios();
        usuarioRepository.CrearNuevoUsuario(usuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult ModificarUsuario(int id)
    {   
        var usuarios = usuarioRepository.GetAllUsuarios();
        var usuarioAMod = usuarios.FirstOrDefault() 
        return View();
    }

    [HttpPost]
    public IActionResult ModificarUsuario(Usuario usuario)
    {   
        var Usuarios = usuarioRepository.GetAllUsuarios();
        usuarioRepository.CrearNuevoUsuario(usuario);
        return RedirectToAction("Index");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
