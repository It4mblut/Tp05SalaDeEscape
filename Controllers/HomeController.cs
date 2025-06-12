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
            escapeBabel.nuevoJuego();
            
            return View(escapeBabel.salaActualVista());

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

            bool cumpleCondicion = true;

            foreach(string objRequerido in escapeBabel.dicPuertas[numPuerta]){

                if (!escapeBabel.dicInventario.ContainsValue(objRequerido))
                {
                    cumpleCondicion=false;
                }
            }


            if (cumpleCondicion)
            {

                escapeBabel.cambiarNumeroSala(escapeBabel.salaActual + 1);
                HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));
                ViewBag.juego = escapeBabel;
                return View(escapeBabel.salaActualVista());
            }
            else
            {
                ViewBag.juego = escapeBabel;
                return View(escapeBabel.salaActualVista());
            }
        }
        else
        {
            ViewBag.juego = escapeBabel;
            return View(escapeBabel.salaActualVista());
        }
    }

    [HttpPost]
    public IActionResult globoDialogo(int numero, string tipo){
        
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        ViewBag.juego = escapeBabel;

        if(escapeBabel.dicPistas.ContainsKey(numero) && (tipo=="pista" || tipo=="acertijo")){
 
            ViewBag.textoPista = escapeBabel.dicPistas[numero];

            ViewBag.numeroDialogo = numero;
            ViewBag.recompensa = escapeBabel.dicRecompensas[numero];
            
            return View(tipo);

        }else{
            return View(escapeBabel.salaActualVista());
        }
        
        
    }




    public IActionResult volverASala(){
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        ViewBag.juego=escapeBabel;
        

        return View(escapeBabel.salaActualVista());
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
        return View(escapeBabel.salaActualVista());
    }

    public IActionResult recibirRecompensa(string recompensaNum){

        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));

        if(escapeBabel.dicRecompensas.ContainsValue(recompensaNum)){
          escapeBabel.nuevoItem(recompensaNum);  
        }

        ViewBag.juego=escapeBabel;
        HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));
        return View(escapeBabel.salaActualVista());
    }
}
