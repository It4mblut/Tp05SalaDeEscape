namespace tpSalaDeEscape.Models;

public class juego{

    public string nombreUsuario {private get; set;}
    public Dictionary<int, string> dicInventario {private get; set;}
    public int maxSlots {private get; set;}
    public int itemSeleccionado {private get; set;}
    public int salaActual {private get; set;}
    public int maxSalas {private get; set;}

    public Dictionary<int, string> dicResoluciones {private get; set;}
    public Dictionary<int, string> dicPuertas {private get; set;}

    
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