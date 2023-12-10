using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Controllers;


public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;

    private TareaRepository tareaRepository;
    private UsuarioRepository usuarioRepository;
    private TableroRepository tableroRepository;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
        usuarioRepository = new UsuarioRepository();
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
                var tareas = tareaRepository.GetAllTareasDeUnUsuario((int)HttpContext.Session.GetInt32("id")!);
                var tareaVM = new ListarTareasViewModel(tareas);
                return View(tareaVM);
            }else
            {
                return RedirectToRoute(new{controller = "Login", action = "Index"});
            }
       
        
    }

    [HttpGet]
    public IActionResult CrearTarea()
    {   
        if (isAdmin())
        {
            return View(new CrearTareaViewModel(tableroRepository.GetAllTableros(),usuarioRepository.GetAllUsuarios()));
        }else
        {
            return RedirectToRoute(new{controller = "Login", action = "Index"});
        }
    }

    [HttpPost]
    public IActionResult CrearTarea(CrearTareaViewModel tareaVM)
    {   
        if (isAdmin())
        {
            var tareaNueva = new Tarea(tareaVM);
            tareaRepository.CrearNuevaTarea(tareaNueva);
            return RedirectToAction("Index");
        }else
        {
           return RedirectToRoute(new{controller = "Login", action = "Index"}); 
        }
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