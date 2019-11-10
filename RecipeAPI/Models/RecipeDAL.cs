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
        // Create method to call RecipePuppyAPI
        private static string baseUrl = "http://www.recipepuppy.com/api";

        public static string CallRecipeAPI(string i, string q)
        {
            HttpWebRequest request = WebRequest.CreateHttp($"{baseUrl}/?i={i}&q={q}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Convert response to a string
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();

            return APIText;
        }

        // Method to search and create list of recipes
        public static List<Recipe> GetRecipe(string i, string q)
        {
            // Return APICall with search parameters as a string
            string APIText = CallRecipeAPI(i, q);

            List<Recipe> recipes = new List<Recipe>();

            // Create JToken to access API and a list to searchthe results
            JToken t = JToken.Parse(APIText);
            List<JToken> results = t["results"].ToList();

            foreach (JToken recipe in results)
            {
                Recipe r = new Recipe(recipe);
                recipes.Add(r);
            }
            
            return recipes;
        }
    }
}
