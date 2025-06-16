using Newtonsoft.Json;

namespace tpSalaDeEscape.Models;

public class globoDialogo
{

    [JsonProperty]
    public string texto { get; private set; }
    
    [JsonProperty]
    public string imagen { get; private set; }


    public globoDialogo(string txt, string img)
    {
        texto = txt;
        imagen = img;
    }

    
}