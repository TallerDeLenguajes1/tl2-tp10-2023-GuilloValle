using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Controllers;


public class TableroController : Controller
{
    private readonly ILogger<UsuarioController> _logger;

    private TableroRepository tableroRepository;

    public TableroController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    public IActionResult Index()
    {   
        if (isAdmin())
        {
            var Tableros = tableroRepository.GetAllTableros();
            var TableroVM = new ListarTableroViewModel(Tableros);
            return View(TableroVM);
        }else if (isOperador())
        {
            var tablero = tableroRepository.GetTableroById((int)HttpContext.Session.GetInt32("id"));
            var tableroVM = new ListarTableroViewModel(tablero);
            return View(tableroVM);
        }else
        {
            return RedirectToRoute(new{controller = "Login", action = "Index"});
        }
        
        
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {   
        if (isAdmin())
        {
            return View(new Tablero());
        } else
        {
            return RedirectToRoute(new{controller = "Login", action = "Index"});
        }
        
    }

    [HttpPost]
    public IActionResult CrearTablero(Tablero tablero)
    {   
        var Tableros = tableroRepository.GetAllTableros();
        tableroRepository.CrearNuevoTablero(tablero);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult ModificarTablero(int idTablero)
    {   
        var Tableros = tableroRepository.GetAllTableros();
        var TableroAMod = Tableros.FirstOrDefault(tabl => tabl.Id == idTablero); 
        return View(TableroAMod);
    }

    [HttpPost]
    public IActionResult ModificarTablero(Tablero tableroNuevo)
    {   
        tableroRepository.ModificarTablero(tableroNuevo);
        return RedirectToAction("Index");
    }
    
    public IActionResult EliminarTablero(int idTablero)
    {
        tableroRepository.EliminarTablero(idTablero);
        return RedirectToAction("Index");
    }

    private bool isAdmin(){
        if(HttpContext.Session != null && HttpContext.Session.GetString("Rol") == "administrador"){
            return true;
        }
        return false;
    }

    private bool isOperador(){
        if(HttpContext.Session != null && HttpContext.Session.GetString("Rol") == "operador"){
            return true;
        }
        return false;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
