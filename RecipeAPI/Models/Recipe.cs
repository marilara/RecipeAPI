using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeAPI.Models
{
    public class Recipe
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public List<string> Ingredients { get; set; }
        public string Thumbnail { get; set; }

        public Recipe()
        {

        }

        public Recipe(JToken t)
        {
            this.Title = t["title"].ToString();
            this.Href = t["href"].ToString();
            List<JToken> ingredient = t["ingredients"].ToList();
            this.Ingredients = new List<string>();
            foreach (JToken ing in ingredient)
            {
                Ingredients.Add(ing.ToString());
            }
            this.Thumbnail = t["thumbnail"].ToString();
        }
    }
}
