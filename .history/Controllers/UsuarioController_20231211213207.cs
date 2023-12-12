using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_GuilloValle.Models;
using tl2_tp10_2023_GuilloValle.ViewModels;
namespace tl2_tp10_2023_GuilloValle.Controllers;
using ConjuntoDeInterfacesRepo;


public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;

    private IUsuarioRepository usuarioRepository;

    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository usuRepo)
    {
        _logger = logger;
        usuarioRepository = usuRepo;
    }

    [HttpGet]
    public IActionResult Index()
    {   
              
        try
        {
            if (isAdmin())
                {
                    var Usuarios = usuarioRepository.GetAllUsuarios();
                    var UsuarioVM = new ListarUsuariosViewModel(Usuarios);
                    return View(UsuarioVM);
                }else if(isOperador())
                        {   var usuario = usuarioRepository.ObtenerUsuarioPorId((int)HttpContext.Session.GetInt32("id")!);
                            var usuario1 = new ListarUsuariosViewModel(usuario);
                            return View(usuario1);
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
    public IActionResult CrearUsuario()
    {   
        
        if(isAdmin()){

        return View(new CrearUsuarioViewModel());

        }
        return RedirectToRoute(new{controller = "Login", action = "Index"});
        
    }

    [HttpPost]
    public IActionResult CrearUsuario(CrearUsuarioViewModel usuarioCVM)
    {   

       try
       {
        if(!ModelState.IsValid) return RedirectToAction("Index");
        if (isAdmin())
        {
          var nuevoUsuario = new Usuario(usuarioCVM);
          usuarioRepository.CrearNuevoUsuario(nuevoUsuario);
          return RedirectToAction("Index");
        }
 
        return RedirectToRoute(new{controller = "Login", action = "Index"});
       }
       catch (System.Exception ex)
       {
        
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
       }
       

    }

    [HttpGet]
    public IActionResult ModificarUsuario(int idUsuario)
    {   
       try
       {
         if (isAdmin())
         {
             var UsuarioAModificar = usuarioRepository.ObtenerUsuarioPorId(idUsuario);   //Busco el usuario a modificar
             var UsuMVM = new ModificarUsuarioViewModel(UsuarioAModificar);              //Lo convierto a usuario de la clase usuario a la clase VM modificar uusario
             return View(UsuMVM);                                                        //Le mando a la vista el VM a la view, ya que para eso usamos VM solo para enviar a Views
         }
 
         return RedirectToRoute(new{controller = "Login", action = "Index"});
       }
       catch (System.Exception ex)
       {
         _logger.LogError(ex.ToString());
         return RedirectToAction("Error");
        
       }
    }                                                                              

    [HttpPost]
    public IActionResult ModificarUsuario(ModificarUsuarioViewModel usuarioNuevo)
    {   
       try
       {
         if(!ModelState.IsValid) return RedirectToAction("Index");
         var usuarioActulizado = new Usuario(usuarioNuevo);         //Paso del view model (cargado con datos en el GET) a Usuario de nuevo
         usuarioRepository.ModificarUsuario(usuarioActulizado);      //Ya con el usuario con el modelo de usuario (la clase) actualizo la base de datos
         return RedirectToAction("Index");                         // vuelvo al index luego de la actualizacion
       }
       catch (System.Exception ex)
       {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        
       }                  
    }
    
    public IActionResult EliminarUsuario(int idUsuario)
    {
       try
       {
         if (isAdmin())
         {  
             usuarioRepository.EliminarUsuario(idUsuario);
             return RedirectToAction("Index");
         }
         return RedirectToAction("Index");
       }
       catch (System.Exception ex)
       {
            _logger.LogError(ex.ToString());
            return RedirectToAction("Error");
        
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
