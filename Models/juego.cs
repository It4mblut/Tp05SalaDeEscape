namespace tpSalaDeEscape.Models;
using Newtonsoft.Json;
public class juego
{

    public string nombreUsuario { get; private set; }
    
    [JsonProperty]
    public int salaActual { get; private set; }
    public int maxSalas { get; private set; }
    public Dictionary<int, sala> DicSalas { get; private set; }

    public juego(string nombreUsuaroi)
    {

        
        maxSalas = 4;

        this.nombreUsuario = nombreUsuaroi;
        DicSalas = new Dictionary<int, sala>();

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

    public void pasarDeSala(){
        int nuevaSala = salaActual + 1;
        salaActual = nuevaSala;
    }

    public void iniciarJuego()
    {
        salaActual = 1;

        DicSalas = new Dictionary<int, sala>()
        {
            {1, new sala("En la puerta ves un candado. Requiere que se ingresen 4 numeros. Deberas buscar por la sala para encontrar pistas sobre la combinacion, suerte encontrando el ultimo numero", "7537",
            new Dictionary<string, globoDialogo>(){
                { "sala1_globo1", new globoDialogo("Primer numero; Si quieres saber quién soy, espera a que llueva. Contando los colores del arcoíris tendrás la prueba.", null)},
                { "sala1_globo2", new globoDialogo("Segundo numero; ¿Qué número tiene el mismo número de letras que el valor que expresa?", null)},
                { "sala1_globo3", new globoDialogo("Tercer numero; Omne trium perfectum", null)},
            })},

            {2, new sala("borges:-¿Conoces la palabra secreta, "+this.nombreUsuario+"? si es asi, dimelo y yo te cedere el paso (puedes interactuar con los cajones)", "silencio",
            new Dictionary<string, globoDialogo>(){
                { "sala2_cajon1", new globoDialogo(null, "images/cajon1.png")},
                { "sala2_cajon2", new globoDialogo(null, "images/cajon2.png")},
                { "sala2_cajon3", new globoDialogo(null, "images/cajon3.png")},
            })},

            { 3, new sala("La puerta requiere una palabra clave que podras formar resolviendo los 3 acertijos ocultos por esta habitacion y juntando las primeras 2 letras de cada uno de manera ordenada", "dragon",
            new Dictionary<string, globoDialogo>(){
                { "sala3_persona", new globoDialogo("1-Me antecede quien cura o enseña, dos letras que el respeto despeña. En puertas de aulas o habitaciones, siempre me usan en presentaciones.", null)},
                { "sala3_libro", new globoDialogo("2-En la ventana soy dama, en el balcón soy señora, en la mesa cortesana  y en el campo labradora.", null)},
                { "sala3_tabla", new globoDialogo(null, "images/tabal.png")},
            })},

            { 4, new sala("Llegaste al final de tu viaje, pero para escapar es necesario que encuentres el secreto de la inmortalidad. Busca por estos libros y encuentralo, pero ten cuidado, la biblioteca de babel intentara engañarte", "palabra",
            new Dictionary<string, globoDialogo>(){
                { "sala4_libro1", new globoDialogo("Soy aquel punto por el cual pasan todas las cosas. Mirame y veras el universo y su contracara y la contracara de su contracara y...", null)},
                { "sala4_libro2", new globoDialogo("En el principio era XXXXX, y XXXXXX era con Dios, y XXXXXX era Dios. (juan 1:1)", null)},
                { "sala4_libro3", new globoDialogo("En el viaje de la vida, no son las metas ni los tesoros lo que más importa, sino quienes caminan a tu lado, compartiendo risas y secretos.", null)},
            })},

        };

    }
    



}