namespace tpSalaDeEscape.Models;

public class sala
{
    public string consigna { get; private set; }
    public string respuesta { get; private set; }
    
    public Dictionary<string, globoDialogo> dicPistas { get; private set; }

    public sala(string consigna, string respuesta, Dictionary<string, globoDialogo> Pistas)
    {
        this.consigna = consigna;
        this.respuesta = respuesta;
        this.dicPistas = Pistas;
    }

    public bool respuestaEsCorrecta(string ingreso)
    {
        return (ingreso == respuesta);
    }
    
}