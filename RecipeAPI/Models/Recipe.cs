using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeAPI.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public string Ingredients { get; set; }
        public string Thumbnail { get; set; }

        public Recipe()
        {

        }

        public Recipe(JToken t)
        {
            this.Title = t["title"].ToString();
            this.Href = t["href"].ToString();
            this.Ingredients = t["ingredients"].ToString();
            this.Thumbnail = t["thumbnail"].ToString();
        }
    }
}
