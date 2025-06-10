using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tpSalaDeEscape.Models;

namespace tpSalaDeEscape.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult iniciar(string opcion=null, string nombreusuario=null){

        if (nombreusuario != null)
        {
            juego escapeBabel = new juego(nombreusuario);
            
            HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));
            ViewBag.juego = escapeBabel;
            return View(salaActualVista(escapeBabel.salaActual, escapeBabel.maxSalas));

        }
        else if (opcion == "historia" || opcion == "tutorial" || opcion == "jugar")
        {
            return View(opcion);
            
        }
        else
        {
            return View("Index");
        }
    }

    private juego inicializarJuego(string nombreusuario)
    {
        juego nuevoJuego = new juego(nombreusuario);


        return nuevoJuego;
    }
    

[HttpPost]
    public IActionResult usarObjeto(int numPuerta){

        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        
        if (escapeBabel.dicPuertas.ContainsKey(numPuerta))
        {

            if (escapeBabel.dicInventario.ContainsValue(escapeBabel.dicPuertas[numPuerta]))
            {
                escapeBabel.cambiarNumeroSala(escapeBabel.salaActual + 1);
                HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));
                ViewBag.juego = escapeBabel;
                return View(salaActualVista(escapeBabel.salaActual, escapeBabel.maxSalas));
            }
            else
            {
                ViewBag.juego = escapeBabel;
                return View(salaActualVista(escapeBabel.salaActual, escapeBabel.maxSalas));
            }
        }
        else
        {
            ViewBag.juego = escapeBabel;
            return View(salaActualVista(escapeBabel.salaActual, escapeBabel.maxSalas));
        }
    }

    [HttpPost]
    public IActionResult globoDialogo(int numeroPista){
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        if(escapeBabel.dicPistas.ContainsKey(numeroPista)){
            ViewBag.textoPista = escapeBabel.dicPistas[numeroPista];
            return View(("pista"+numeroPista));
        }else{
            return View(salaActualVista(escapeBabel.salaActual, escapeBabel.maxSalas));
        }
        
        
    }
    public IActionResult volverASala(){
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        ViewBag.juego=escapeBabel;
        

        return View(salaActualVista(escapeBabel.salaActual, escapeBabel.maxSalas));
    }

    [HttpPost]
    public IActionResult responderAcertijo(string respuestaUsuario, int numeroAcertijo, string recompensa){
        
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        if(escapeBabel.dicResoluciones.ContainsKey(numeroAcertijo)){
            if(escapeBabel.dicResoluciones[numeroAcertijo]==respuestaUsuario){

                ViewBag.acertijoResuleto=numeroAcertijo;
                ViewBag.juego=escapeBabel;

                return View("acierto");
            }else{
                
                ViewBag.juego=escapeBabel;
                return View ("equivocacion");
            }
        }
        ViewBag.juego=escapeBabel;
        return View(salaActualVista(escapeBabel.salaActual, escapeBabel.maxSalas));
    }

    private string salaActualVista(int salaActual, int maximaSala){
        string sala="sala";
        if(salaActual<=maximaSala){
            sala=sala+salaActual;
        }else{
            sala="final";
        }
        return sala;
    }


    
}
