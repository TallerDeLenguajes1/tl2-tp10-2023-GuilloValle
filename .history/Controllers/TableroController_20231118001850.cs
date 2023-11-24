using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
namespace tl2_tp10_2023_GuilloValle.Controllers;


public class TableroController : Controller
{
    private readonly ILogger<TableroRepository> _logger;

    private TableroRepository tableroRepository;

    public TableroController(ILogger<TableroRepository> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    public IActionResult Index()
    {   
        var Tableros = tableroRepository.GetAllTableros();
        return View(Tableros);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {   
        return View(new Tablero());
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
