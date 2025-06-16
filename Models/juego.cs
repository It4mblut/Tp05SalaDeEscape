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

        if (nuevaSala <= maxSalas)
        {
            salaActual = nuevaSala;
        }
    }

    public void iniciarJuego()
    {
        salaActual = 1;

        DicSalas = new Dictionary<int, sala>()
        {
            {1, new sala("En la puerta ves un candado. Requiere que se ingresen 4 numeros. Deberas buscar por la sala para encontrar pistas sobre la combinacion, suerte encontrando el ultimo numero", "1063",
            new Dictionary<string, globoDialogo>(){
                { "sala1_globo1", new globoDialogo("Primer numero; El número de lados de la figura perfecta, si sólo uno bastara para definirla.", null)},
                { "sala1_globo2", new globoDialogo("Segundo numero; En el día que se repite, el mismo número es siempre primero y siempre último", null)},
                { "sala1_globo3", new globoDialogo("Tercer numero; El número de letras en el nombre de aquel que imaginó la biblioteca sin fin.", null)},
            })},

            {2, new sala("borges:-¿Conoces la palabra secreta "+this.nombreUsuario+"? si es asi, dimelo y yo te cedere el paso", "silencio",
            new Dictionary<string, globoDialogo>(){
                { "sala2_cajon1", new globoDialogo(null, "*hacer imagen")},
                { "sala2_cajon2", new globoDialogo(null, "*hacer imagen")},
            })},

            { 3, new sala("La puerta requiere una palabra clave que podras formar resolviendo los 3 acertijos ocultos por esta habitacion y juntando sus primeras 2 letras", "dragon",
            new Dictionary<string, globoDialogo>(){
                { "sala3_persona", new globoDialogo("1-Me antecede quien cura o enseña, dos letras que el respeto despeña. En puertas de aulas o habitaciones, siempre me usan en presentaciones.", null)},
                { "sala3_libro", new globoDialogo("2-Cae del cielo, corre en ríos, calma incendios, limpia líos. No tiene forma, pero da vida, y sin su esencia, nada anida.", null)},
                { "sala3_tabla", new globoDialogo(null, "*imagen --> 3-Estoy en cada interruptor, soy el opuesto del apagador.")},
            })},

            { 4, new sala("Llegaste al final de tu viaje, pero para escapar es necesario que encuentres el secreto de la inmortalidad. Busca por estos libros y encuentralo, pero ten cuidado, la biblioteca de babel intentara engañarte", "verbo",
            new Dictionary<string, globoDialogo>(){
                { "sala4_libro1", new globoDialogo("Soy aquel punto por el cual pasan todas las cosas. Mirame y veras el universo y su contracara y la contracara de su contracara y...", null)},
                { "sala4_libro2", new globoDialogo("En el principio era el -Yo-, y el -Yo- era con Dios, y el -Yo- era Dios. (juan 1:1)", null)},
                { "sala4_libro3", new globoDialogo("En el viaje de la vida, no son las metas ni los tesoros lo que más importa, sino quienes caminan a tu lado, compartiendo risas y secretos.", null)},
            })},

        };

    }
    



}