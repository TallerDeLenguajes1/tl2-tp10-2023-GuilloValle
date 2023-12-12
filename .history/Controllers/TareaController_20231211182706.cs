using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Controllers;
using ConjuntoDeInterfacesRepo;


public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;

    private ITareaRepository tareaRepository;
    private IUsuarioRepository usuarioRepository;
    private ITableroRepository tableroRepository;

    public TareaController(ILogger<TareaController> logger,IUsuarioRepository usuarioRepo,ITableroRepository tableroRepo,ITareaRepository tareaRepo)
    {
        _logger = logger;
        tareaRepository = tareaRepo;
        usuarioRepository = usuarioRepo;
        tableroRepository = tableroRepo;
    }

    public IActionResult Index()
    {  
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
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
        if(!ModelState.IsValid) return RedirectToAction("Index");
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
        if (isAdmin())
       {
         var TareaAModificar = tareaRepository.GetTareaById(idTarea);
         var TareaVM = new ModificarTareaViewModel(TareaAModificar);
         return View(TareaVM);
       }else
       {
        return RedirectToRoute(new{controller = "Login", action = "Index"});
       }
        
    }

    [HttpPost]
    public IActionResult ModificarTarea(ModificarTareaViewModel TareaNuevaVM)
    {   
       if(!ModelState.IsValid) return RedirectToAction("Index");
       if (isAdmin())
       {
         var tareaActualizada = new Tarea(TareaNuevaVM);
         tareaRepository.ModificarTarea(tareaActualizada);
         return RedirectToAction("Index");
       }else
       {
        return RedirectToRoute(new{controller = "Login", action = "Index"});
       }

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