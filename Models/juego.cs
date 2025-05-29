namespace tpSalaDeEscape.Models;

public class juego{

    public string nombreUsuario { get; private set;}
    public Dictionary<int, string> dicInventario { get; private set;}
    public int maxSlots { get; private set;}
    public int itemSeleccionado { get; private set;}
    public int salaActual { get; private set;}
    public int maxSalas { get; private set;}

    public Dictionary<int, string> dicResoluciones { get; private set;}
    public Dictionary<int, string> dicPuertas { get; private set;}

    
    public juego(string nombreUsuaroi){

        this.dicInventario=new Dictionary<int, string>();
        this.dicPuertas=new Dictionary<int, string>();
        this.dicResoluciones=new Dictionary<int, string>();
        salaActual=1;
        itemSeleccionado=0;
        maxSlots=6;
        this.nombreUsuario=nombreUsuaroi;


    }

    public void cambiarItemSeleccionado(int itemSeleccionado){
        if(itemSeleccionado<=maxSlots && itemSeleccionado>=0){
            maxSlots=itemSeleccionado;
        }
    }
    public void cambiarNumeroSala(int nuevaSala){
        if(nuevaSala>=1 && nuevaSala<=maxSalas){
            salaActual=nuevaSala;
        }
    }
    public void nuevoItem(string nuevoItem){
        if(dicInventario.Count>=0 && dicInventario.Count<=maxSlots){
            dicInventario.Add(dicInventario.Count, nuevoItem);

        }
    }

    












}