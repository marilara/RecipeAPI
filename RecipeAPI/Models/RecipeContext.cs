using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeAPI.Models
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-F30FORNB\SQLEXPRESS;Initial Catalog=Favorites;Trusted_Connection=True;");
        }
    }
}
