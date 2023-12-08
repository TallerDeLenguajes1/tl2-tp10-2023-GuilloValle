using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Controllers;


public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;

    private TareaRepository tareaRepository;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    public IActionResult Index()
    {   
        if (isAdmin())
        {
            var tareas = tareaRepository.GetAllTareas();
            var tareasVM = new ListarTareasViewModel(tareas);
            return View(tareasVM); 
        }else if (isOperador())
            {
                var tarea = tareaRepository.GetTareaById((int)HttpContext.Session.GetInt32("id")!);
                var tareaVM = new ListarTareasViewModel(tarea);
                return View(tareaVM);
            }else
            {
                return RedirectToRoute(new{controller = "Login", action = "Index"});
            }
       
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CrearTarea()
    {   
        if (isAdmin())
        {
            return View(new Tarea());
        }else
        {
            return RedirectToRoute(new{controller = "Login", action = "Index"});
        }
    }

    [HttpPost]
    public IActionResult CrearTarea(Tarea tarea)
    {   
        tareaRepository.CrearNuevaTarea(tarea);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult ModificarTarea(int idTarea)
    {   
        var Tareas = tareaRepository.GetAllTareas();
        var TareaAMod = Tareas.FirstOrDefault(tarea => tarea.Id == idTarea); 
        return View(TareaAMod);
    }

    [HttpPost]
    public IActionResult ModificarTarea(Tarea TareaNueva)
    {   
        tareaRepository.ModificarTarea(TareaNueva);
        return RedirectToAction("Index");
    }
    
    public IActionResult EliminarTarea(int idTarea)
    {
        tareaRepository.EliminarTarea(idTarea);
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