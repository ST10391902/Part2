using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // Recipe class with properties for name, ingredients, and steps
    public class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> Ingredients { get; set; }
        private List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        // Calculate total calories of all ingredients in the recipe
        public double CalculateTotalCalories()
        {
            double totalCalories = Ingredients.Sum(ingredient => ingredient.Calories);
            return totalCalories;
        }

        // Delegate to notify when total calories exceed 300
        public delegate void CaloriesExceedNotification(string recipeName, double totalCalories);

        // Event to trigger calorie notification
        public event CaloriesExceedNotification OnCaloriesExceed;

        // Method to check and notify if total calories exceed 300
        public void CheckTotalCalories()
        {
            double totalCalories = CalculateTotalCalories();
            if (totalCalories > 300)
            {
                OnCaloriesExceed?.Invoke(Name, totalCalories);
            }
        }

        public override string ToString()
        {
            string recipeDetails = $"Name: {Name}\n\nIngredients:\n";
            foreach (var ingredient in Ingredients)
            {
                recipeDetails += $"{ingredient}\n";
            }

            recipeDetails += "\nSteps:\n";
            foreach (var step in Steps)
            {
                recipeDetails += $"{step}\n";
            }

            recipeDetails += $"\nTotal Calories: {CalculateTotalCalories()}";
            return recipeDetails;
        }
    }
}
