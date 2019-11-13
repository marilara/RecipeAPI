using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    public class HomeController : Controller
    {
        public RecipeContext db = new RecipeContext();
        public IActionResult Index()
        {
                return View();
        }

        public IActionResult Favorites()
        {
            List<Recipe> favoritesList = db.Recipes.ToList();
            return View(favoritesList);
        }

        public IActionResult AddFavorites([Bind("Title,Href,Ingredients,Thumbnail")] Recipe r)
        {
            db.Add(r);
            db.SaveChanges();
            return RedirectToAction("Favorites");
        }
        
        public IActionResult DeleteFavorites(int id)
        {
            Recipe recipes = db.Recipes.Find(id);
            db.Recipes.Remove(recipes);
            db.SaveChanges();
            return RedirectToAction("Favorites");
        }

        public IActionResult Results(string i, string q)
        {
            List<Recipe> recipes = RecipeDAL.GetRecipe(i, q);

            if (recipes != null)
            {
                return View(recipes);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
