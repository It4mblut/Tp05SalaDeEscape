namespace tpSalaDeEscape.Models;

public class sala
{
    public string consigna { get; private set; }
    public string respuesta { get; private set; }
    public Dictionary<string, globoDialogo> Pistas { get; private set; }

    public sala(string consigna, string respuesta, Dictionary<string, globoDialogo> Pistas)
    {
        this.consigna = consigna;
        this.respuesta = respuesta;
        this.Pistas=Pistas;
    }
    
}