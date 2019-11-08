using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RecipeAPI.Models
{
    public class RecipeDAL
    {
        private static string baseUrl = "http://www.recipepuppy.com/api";

        public static Recipe GetRecipe(string i="", string q="")
        {
            HttpWebRequest request = WebRequest.CreateHttp($"{baseUrl}/?i={i}&q={q}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Convert response to a string
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();

            JToken t = ParseJsonString(APIText);

            Recipe r = new Recipe(t);

            return r;

        }

        public static JToken ParseJsonString(string text)
        {
            JToken output = JToken.Parse(text);
            return output;
        }
    }
}
