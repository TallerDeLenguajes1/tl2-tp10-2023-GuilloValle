using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
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
    public IActionResult ModificarTablero(int id)
    {   
        var Tableros = tableroRepository.GetAllTableros();
        var TableroAMod = Tableros.FirstOrDefault(tabl => tabl.Id == id); 
        return View(usuarioAMod);
    }

    [HttpPost]
    public IActionResult ModificarTablero(int id,Usuario usuarioNuevo)
    {   
        tableroRepository.ModificarUsuario(id,usuarioNuevo);
        return RedirectToAction("Index");
    }
    
   /* public IActionResult EliminarUsuario(int idUsuario)
    {
        usuarioRepository.EliminarUsuario(idUsuario);
        return RedirectToAction("Index");
    }*/

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
