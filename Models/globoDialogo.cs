namespace tpSalaDeEscape.Models;

public class globoDialogo
{
    public string texto { get; private set; }
    public string imagen { get; private set; }


    public globoDialogo(string txt, string img)
    {
        texto = txt;
        imagen = img;
    }

    
}