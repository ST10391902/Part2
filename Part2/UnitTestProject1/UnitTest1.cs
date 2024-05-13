using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RecipeAppTests
{
    [TestFixture]
    public class RecipeTests
    {
        public object FoodGroup { get; private set; }

        [Test]
        public void CalculateTotalCalories_ReturnsCorrectTotal()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.AddIngredient(new Ingredient("Coffee Beans", 100, "g", 200, FoodGroup.Other)); // 200 calories
            recipe.AddIngredient(new Ingredient("Milk", 200, "ml", 100, FoodGroup.Dairy)); // 100 calories
            recipe.AddIngredient(new Ingredient("Sugar", 20, "g", 80, FoodGroup.Other)); // 80 calories

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(380, totalCalories); // 200 + 100 + 80 = 380
        }
    }

    internal class TestFixtureAttribute : Attribute
    {
    }

    internal class TestAttribute : Attribute
    {
    }

    internal class Recipe
    {
        public Recipe()
        {
        }

        internal void AddIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        internal double CalculateTotalCalories()
        {
            throw new NotImplementedException();
        }
    }

    internal class Ingredient
    {
        private string v1;
        private int v2;
        private string v3;
        private int v4;
        private object other;

        public Ingredient(string v1, int v2, string v3, int v4, object other)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.other = other;
        }
    }
}
