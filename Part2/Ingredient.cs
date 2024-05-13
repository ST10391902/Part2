using System;

namespace RecipeApp
{
    // Enum representing different food groups
    public enum FoodGroup
    {
        Grains,
        Fruits,
        Vegetables,
        Protein,
        Dairy,
        Fats,
        Other
    }

    // Ingredient class with properties for name, quantity, unit, calories, and food group
    public class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; }
        public string Unit { get; }
        public double Calories { get; }
        public FoodGroup FoodGroup { get; }

        public Ingredient(string name, double quantity, string unit, double calories, FoodGroup foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name} ({Calories} calories)";
        }
    }
}
