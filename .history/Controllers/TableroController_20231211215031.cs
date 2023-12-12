using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Controllers;
using ConjuntoDeInterfacesRepo;


public class TableroController : Controller
{
    private readonly ILogger<UsuarioController> _logger;

    private ITableroRepository tableroRepository;
    private IUsuarioRepository usuarioRepository;

    public TableroController(ILogger<UsuarioController> logger,ITableroRepository tableroRepo,IUsuarioRepository usuarioRepo)
    {
        _logger = logger;
        tableroRepository = tableroRepo;
        usuarioRepository = usuarioRepo;
    }

    public IActionResult Index()
    {   
        try
        {
            if (isAdmin())
            {
                var Tableros = tableroRepository.GetAllTableros();
                var TableroVM = new ListarTableroViewModel(Tableros);
                return View(TableroVM);
            }else if (isOperador())
            {
                var tablero = tableroRepository.GetTableroByIdPropietario((int)HttpContext.Session.GetInt32("id"));
                var tableroVM = new ListarTableroViewModel(tablero);
                return View(tableroVM);
            }else
            {
                return RedirectToRoute(new{controller = "Login", action = "Index"});
            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        }
        
        
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {   
        if (isAdmin())
        {
            return View(new CrearTableroViewModel(usuarioRepository.GetAllUsuarios()));
        } else
        {
            return RedirectToRoute(new{controller = "Login", action = "Index"});
        }
        
    }

    [HttpPost]
    public IActionResult CrearTablero(CrearTableroViewModel tableroVM)
    {   
       try
       {
         if(!ModelState.IsValid) return RedirectToAction("Index");
         if (isAdmin())
         {
             var tableroNuevo = new Tablero(tableroVM);
             tableroRepository.CrearNuevoTablero(tableroNuevo);
             return RedirectToAction("Index");
         }else
         {
             return RedirectToRoute(new{controller = "Login", action = "Index"});
         }
       }
       catch (System.Exception ex)
       {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        
       }
    }

    [HttpGet]
    public IActionResult ModificarTablero(int idTablero)
    {  
       
       if (isAdmin())
       {
         var TableroAMod = tableroRepository.GetTableroById(idTablero);
         var tableroVM = new ModificarTableroViewModel(TableroAMod);
         return View(tableroVM);
       }else
       {
        return RedirectToRoute(new{controller = "Login", action = "Index"});
       }
    }

    [HttpPost]
    public IActionResult ModificarTablero(ModificarTableroViewModel tableroNuevo)
    {   
        
        if(!ModelState.IsValid) return RedirectToAction("Index");
        if (isAdmin())
        {
            var tableroActualizado = new Tablero(tableroNuevo);
            tableroRepository.ModificarTablero(tableroActualizado);
            return RedirectToAction("Index");
        }else
       {
        return RedirectToRoute(new{controller = "Login", action = "Index"});
       }
    }
    
    public IActionResult EliminarTablero(int idTablero)
    {
       if (isAdmin())
       {
         tableroRepository.EliminarTablero(idTablero);
         return RedirectToAction("Index");
       }else
       {
        return RedirectToAction("Index");
       }
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
