using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
                return View();
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
