using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            Console.WriteLine("Welcome to the Recipe App!");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a recipe");
                Console.WriteLine("2. Display recipes");
                Console.WriteLine("3. Enter your choice: ");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateRecipe(recipeManager);
                        break;
                    case "2":
                        DisplayRecipes(recipeManager);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.WriteLine("\nThank you for using the Recipe App!");
        }

        static void CreateRecipe(RecipeManager recipeManager)
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("\nEnter recipe details:");

            Console.Write("Recipe name: ");
            recipe.Name = Console.ReadLine();

            Console.Write("Number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Name of ingredient {i + 1}: ");
                string ingredientName = Console.ReadLine();

                Console.Write($"Quantity of {ingredientName}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Unit of measurement for {ingredientName}: ");
                string unit = Console.ReadLine();

                Console.Write($"Calories for {ingredientName}: ");
                double calories = double.Parse(Console.ReadLine());

                Console.Write($"Food group for {ingredientName}: ");
                string foodGroupStr = Console.ReadLine();
                FoodGroup foodGroup;
                if (!Enum.TryParse(foodGroupStr, out foodGroup))
                {
                    Console.WriteLine("Invalid food group. Defaulting to Other.");
                    foodGroup = FoodGroup.Other;
                }

                recipe.AddIngredient(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
            }

            Console.Write("Number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string stepDescription = Console.ReadLine();
                recipe.AddStep(stepDescription);
            }

            recipe.OnCaloriesExceed += HandleCaloriesExceed;
            recipeManager.AddRecipe(recipe);
        }

        static void DisplayRecipes(RecipeManager recipeManager)
        {
            Console.WriteLine("\nRecipes:");
            List<Recipe> recipes = recipeManager.GetAllRecipes();
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }

            Console.Write("Enter the name of the recipe to display details: ");
            string recipeName = Console.ReadLine();

            Recipe selectedRecipe = recipeManager.GetRecipeByName(recipeName);
            if (selectedRecipe != null)
            {
                Console.WriteLine("\nRecipe Details:");
                Console.WriteLine(selectedRecipe);
                selectedRecipe.CheckTotalCalories();
            }
            else
            {
                Console.WriteLine($"Recipe '{recipeName}' not found.");
            }
        }

        static void HandleCaloriesExceed(string recipeName, double totalCalories)
        {
            Console.WriteLine($"Warning: Recipe '{recipeName}' has exceeded 300 calories. Total Calories: {totalCalories}");
        }
    }
}
