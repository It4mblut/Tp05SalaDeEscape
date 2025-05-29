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
    public IActionResult iniciar(string opcion, string nombreusuario=null){

        if(nombreusuario!=null){
            juego escapeBabel = new juego(nombreusuario);
            HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));
            ViewBag.juego=escapeBabel;
            return View(salaActualVista(escapeBabel.salaActual));
        }else if(opcion=="historia"){
            return View("historia");


        }else{
            return View("tutorial");
        }
    }
    public IActionResult cambiarItem(int item){
        juego escapeBabel =objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        escapeBabel.cambiarItemSeleccionado(item);
        HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));
        return View(salaActualVista(escapeBabel.salaActual));
    }

    public IActionResult usarObjeto(int numPuerta){
        juego escapeBabel=objeto.stringToObject<juego>(HttpContext.Session.GetString("babel"));
        if(escapeBabel.dicPuertas.ContainsKey(numPuerta) && escapeBabel.dicInventario.ContainsKey(escapeBabel.itemSeleccionado)){

            if(escapeBabel.dicPuertas[numPuerta] == escapeBabel.dicInventario[escapeBabel.itemSeleccionado]){
                escapeBabel.cambiarNumeroSala(escapeBabel.salaActual+1);
                HttpContext.Session.SetString("babel", objeto.objectToString(escapeBabel));
                return View(salaActualVista(escapeBabel.salaActual));
            }else{
                return View (salaActualVista(escapeBabel.salaActual));
            }
        }else{
            return View(salaActualVista(escapeBabel.salaActual));
        }
    }






    public IActionResult responderAcertijo(string respuestaUsuario, int numeroAcertijo, string recompensa){



        return View();
    }

    private string salaActualVista(int salaActual){
        string sala="sala";
        sala+=salaActual;
        return sala;
    }
    
}
