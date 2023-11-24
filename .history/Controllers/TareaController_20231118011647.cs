using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
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
        var Tareas = tareaRepository.GetAllTareas();
        return View(Tareas);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CrearTarea()
    {   
        return View(new Tarea());
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}