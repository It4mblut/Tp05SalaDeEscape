namespace tpSalaDeEscape.Models;

public class juego{

    public string nombreUsuario { get; private set;}
    public Dictionary<int, string> dicInventario { get; private set;}
    public int salaActual { get; private set;}
    public int maxSalas { get; private set;}

    public Dictionary<string, string> dicResoluciones { get; private set;}
    public Dictionary<string, List<string>> dicPuertas { get; private set;}
    public Dictionary<string, string> dicPistas { get; private set;}
    public Dictionary<string, string> dicRecompensas { get; private set;}
    
    public juego(string nombreUsuaroi){

        this.dicInventario=new Dictionary<int, string>();
        
        salaActual=2;
        maxSalas=4;
        this.nombreUsuario=nombreUsuaroi;


    }


    public void cambiarNumeroSala(int nuevaSala){
        if(nuevaSala>=1 && nuevaSala<=maxSalas){
            salaActual=nuevaSala;
        }
    }
    public void nuevoItem(string nuevoItem){

        if (nuevoItem == "../images/pedazoLlave1.png" || nuevoItem == "../images/pedazoLlave2.png")
        {
            if (dicInventario.ContainsValue("../images/pedazoLlave1.png") && !dicInventario.ContainsValue("../images/pedazoLlave2.png"))
            {
                dicInventario.Add(dicInventario.Count + 1, "../images/pedazoLlave2.png");

            }
            else if (dicInventario.ContainsValue("../images/pedazoLlave2.png"))
            {
                dicInventario.Add(dicInventario.Count + 1, "../images/llave3.png");
            }
            else
            { 
                dicInventario.Add(dicInventario.Count + 1, "../images/pedazoLlave1.png");
            }
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
        this.dicRecompensas=new Dictionary<string, string>{

            {"Llave1","../images/llave1.png"},

            {"Llave2","../images/llave2.png"},

            {"Llave3","../images/llave3.png"},

            {"pedazoLlave1","../images/pedazoLlave1.png"},
            {"pedazoLlave2","../images/pedazoLlave2.png"},
            {"crowbar","../images/crowbar.webp"},

            {"soga","../images/soga.webp"},
            {"piedra","../images/piedra.jfif"},
            {"libroAleph","../images/libro.webp"},
        };

        this.dicPuertas=new Dictionary<string, List<string>>{

            {"puerta1",new List<string>() {"../images/llave1.png"}},
            {"puerta2",new List<string>() {"../images/llave2.png"}},
            {"puerta3",new List<string>() {"../images/llave3.png"}}, 
            {"puerta4",new List<string>() {"../images/soga.webp", "../images/piedra.jfif", "../images/libro.webp"}}

        };

        this.dicPistas=new Dictionary<string, string>{

            {"sala1_libro1","Primer numero; El número de lados de la figura perfecta, si sólo uno bastara para definirla."},
            {"sala1_libro2","Segundo numero; En el día que se repite, el mismo número es siempre primero y siempre último"},
            {"sala1_libro3","Tercer numero; El número de letras en el nombre de aquel que imaginó la biblioteca sin fin."},
            {"Llave1","Busca los libros que contienen pistas. El codigo requerira 4 numeros, suerte encontrando el ultimo"},

            {"sala2_libro","No soy visto, pero todos me sienten. Me oculto entre letras, pero no soy palabra. En una sala abarrotada, me notás cuando me voy. Puedo ser calma o amenaza, un regalo incómodo o un castigo intencional. Habito el espacio entre preguntas. No tengo voz, pero soy la respuesta de muchos.¿Quién soy?"},
            {"Llave2","¿Conoces la palabra secreta "+this.nombreUsuario+"? si es asi, dimelo y yo te recompensare prontamente"},

            {"pedazoLlave1","No tengo pies pero todos me mueven, no hablo pero soy parte de mil batallas, blanco o negro siempre sigo órdenes, en el juego de reyes soy muy libre, pero fuera del tablero no soy nada."},
            {"pedazoLlave1","Estoy delante de todos pero nunca me ves llegar, me abro para que pases y me cierro cuando te vas, soy el principio de una entrada pero también el fin de un encierro."},

            {"sala4_candado","Multiplicá la cantidad de cuentos en “El Aleph”, el singular numero del diablo, las letras en “Ficciones” y las letras en “Biblioteca”"}
            

        };
        this.dicResoluciones=new Dictionary<string, string>{

            {"sala1_candado","1063"},

            {"sala2_persona","silencio"},

            {"sala3_persona","reina"},
            {"sala3_candado","puerta"},

            {"sala4_candado","9180"},


        };









    }
}