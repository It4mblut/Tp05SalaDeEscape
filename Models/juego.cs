namespace tpSalaDeEscape.Models;

public class juego{

    public string nombreUsuario { get; private set;}
    public Dictionary<int, string> dicInventario { get; private set;}
    public int salaActual { get; private set;}
    public int maxSalas { get; private set;}

    public Dictionary<int, string> dicResoluciones { get; private set;}
    public Dictionary<int, string> dicPuertas { get; private set;}
    public Dictionary<int, string> dicPistas { get; private set;}

    
    public juego(string nombreUsuaroi){

        this.dicInventario=new Dictionary<int, string>();
        this.dicPuertas=new Dictionary<int, string>();
        this.dicResoluciones=new Dictionary<int, string>();
        this.dicPistas=new Dictionary<int, string>();
        salaActual=1;
        maxSalas=4;
        this.nombreUsuario=nombreUsuaroi;


    }

    public void InicializarJuego(){ //ESTO HAY QUE HACERLO URGENTE
        
    }

    public void cambiarNumeroSala(int nuevaSala){
        if(nuevaSala>=1 && nuevaSala<=maxSalas){
            salaActual=nuevaSala;
        }
    }
    public void nuevoItem(string nuevoItem){
        if(!dicInventario.ContainsValue(nuevoItem)){
            dicInventario.Add(dicInventario.Count, nuevoItem);
        }
    }

    public string salaActualVista(){
        string sala="sala";
        if(salaActual<=maxSalas){
            sala=sala+salaActual;
        }else{
            sala="final";
        }
        return sala;
    }


}