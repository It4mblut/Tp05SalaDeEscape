using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tpSalaDeEscape.Models;
using Newtonsoft.Json;

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
            escapeBabel.iniciarJuego();

            HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));
            ViewBag.juego = escapeBabel;
            ViewBag.consigna = escapeBabel.DicSalas[escapeBabel.salaActual].consigna;
            return View(escapeBabel.salaActualVista());

        }
        else if (opcion == "historia" || opcion == "tutorial" || opcion == "jugar" || opcion=="desarrolladores")
        {
            return View(opcion);

        }else {

            return View("Index");
        }
    }

    public IActionResult irASala(){
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));

        ViewBag.juego=escapeBabel;
        ViewBag.consigna = escapeBabel.DicSalas[escapeBabel.salaActual].consigna;

        return View(escapeBabel.salaActualVista());
    }

    [HttpPost]
    public IActionResult responderAcertijo(string respuestaUsuario){
        
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        ViewBag.juego=escapeBabel;

        
        if (escapeBabel.DicSalas[escapeBabel.salaActual].respuestaEsCorrecta(respuestaUsuario))
        {
            escapeBabel.pasarDeSala();
            HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));

            return View("acierto");
        }
        else
        {
            return View("equivocacion");
        }
    }

    public IActionResult irAGloboDialogo(string globoKey)
    {
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        


        if (escapeBabel.DicSalas[escapeBabel.salaActual].dicPistas.ContainsKey(globoKey))
        {
            ViewBag.pistaTxt = escapeBabel.DicSalas[escapeBabel.salaActual].dicPistas[globoKey].texto;
            ViewBag.pistaImg = escapeBabel.DicSalas[escapeBabel.salaActual].dicPistas[globoKey].imagen;
            return View("pista");
        }
        else
        { 
            ViewBag.juego=escapeBabel;
            return View(escapeBabel.salaActualVista());
        }
    }
    
}
