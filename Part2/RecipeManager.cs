
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // RecipeManager class to manage recipes
    public class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public List<Recipe> GetAllRecipes()
        {
            return recipes.OrderBy(r => r.Name).ToList();
        }

        public Recipe GetRecipeByName(string name)
        {
            return recipes.FirstOrDefault(r => r.Name == name);
        }
    }
}
