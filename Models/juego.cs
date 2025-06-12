namespace tpSalaDeEscape.Models;

public class juego{

    public string nombreUsuario { get; private set;}
    public Dictionary<int, string> dicInventario { get; private set;}
    public int salaActual { get; private set;}
    public int maxSalas { get; private set;}

    public Dictionary<int, string> dicResoluciones { get; private set;}
    public Dictionary<int, List<string>> dicPuertas { get; private set;}
    public Dictionary<int, string> dicPistas { get; private set;}
    public Dictionary<int, string> dicRecompensas { get; private set;}
    
    public juego(string nombreUsuaroi){

        //this.dicInventario=new Dictionary<int, string>();
        //this.dicPuertas=new Dictionary<int, string>();
        //this.dicResoluciones=new Dictionary<int, string>();
        //this.dicRecompensas=new Dictionary<int, string>();

        
        //this.dicPistas=new Dictionary<int, string>();
        
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
        if(nuevoItem == "../images/pedazoLlave1.png"){
            dicInventario.Add(dicInventario.Count, "../images/pedazoLlave2.png");

        }else if(nuevoItem == "../images/pedazoLlave2.png"){
            dicInventario.Add(dicInventario.Count, "../images/llave3.png");

        }else if(!dicInventario.ContainsValue(nuevoItem)){
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

    public void nuevoJuego(){
        this.dicRecompensas=new Dictionary<int, string>{

            {1,"../images/llave1.png"},

            {2,"../images/llave2.png"},

            {3,"../images/llave3.png"},

            {4,"../images/pedazoLlave1.png"},
            {5,"../images/pedazoLlave2.png"},
            {13,"../images/crowbar.webp"},

            {11,"../images/soga.webp"},
            {12,"../images/piedra.jfif"},
            {6,"../images/libro.webp"},
        };

        this.dicPuertas=new Dictionary<int, List<string>>{

            {1,new List<string>() {"../images/llave1.png"}},
            {2,new List<string>() {"../images/llave2.png"}},
            {3,new List<string>() {"../images/llave3.png"}}, 
            {4,new List<string>() {"../images/soga.webp", "../images/piedra.jfif", "../images/libro.webp"}}

        };

        this.dicPistas=new Dictionary<int, string>{

            {21,"Primer numero; El número de lados de la figura perfecta, si sólo uno bastara para definirla."},
            {22,"Segundo numero; En el día que se repite, el mismo número es siempre primero y siempre último"},
            {23,"Tercer numero; El número de letras en el nombre de aquel que imaginó la biblioteca sin fin."},
            {1,"Busca los libros que contienen pistas. El codigo requerira 4 numeros, suerte encontrando el ultimo"},

            {24,"No soy visto, pero todos me sienten. Me oculto entre letras, pero no soy palabra. En una sala abarrotada, me notás cuando me voy. Puedo ser calma o amenaza, un regalo incómodo o un castigo intencional. Habito el espacio entre preguntas. No tengo voz, pero soy la respuesta de muchos.¿Quién soy?"},
            {2,"¿Conoces la palabra secreta @ViewBag.juego.nombreUsuario? si es asi, dimelo y yo te recompensare prontamente"},

            {4,"No tengo pies pero todos me mueven, no hablo pero soy parte de mil batallas, blanco o negro siempre sigo órdenes, en el juego de reyes soy el más libre, pero fuera del tablero no soy nada."},
            {5,"Estoy delante de todos pero nunca me ves llegar, me abro para que pases y me cierro cuando te vas, soy el principio de una entrada pero también el fin de un encierro."},

            

        };
        this.dicResoluciones=new Dictionary<int, string>{

            {1,"1063"},

            {2,"silencio"},

            {4,"reina"},
            {5,"puerta"},



        };









    }
}