using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
//yeaux
internal static class Utils {
    public static void Log(this Object me){
        Console.WriteLine(JsonConvert.SerializeObject(me));
    }
}