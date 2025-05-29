namespace tpSalaDeEscape.Models;
using Newtonsoft.Json;

public static class objeto{

    public static string objectToString<T>(T? obj){
        return JsonConvert.SerializeObject(obj);
    }


    public static T? stringToObject<T>(string txt){

        if(string.IsNullOrEmpty(txt)){
        return default;
        }else{
            return JsonConvert.DeserializeObject<T>(txt);
        }
    }








}