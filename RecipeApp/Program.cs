using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Enter the details for a recipe:");
            Console.Write("Number of ingredients: ");
            int ingredientCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Ingredient {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Quantity for {name}: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient(name, quantity, unit);
            }

            Console.Write("Number of steps: ");
            int stepCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string stepDescription = Console.ReadLine();
                recipe.AddStep(stepDescription);
            }

            Console.WriteLine("\nRecipe details:");
            recipe.DisplayRecipe();

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Scale recipe");
            Console.WriteLine("2. Reset quantities");
            Console.WriteLine("3. Clear all data");
            Console.WriteLine("4. Exit");

            bool exit = false;
            while (!exit)
            {
                Console.Write("Enter your choice: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        recipe.ScaleRecipe();
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        recipe.ResetQuantities();
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.ClearRecipe();
                        Console.WriteLine("Recipe data cleared.");
                        exit = true;
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }

    class Recipe
    {
        private string[] ingredients;
        private int[] quantities;
        private string[] units;
        private string[] steps;

        public Recipe()
        {
            ingredients = new string[0];
            quantities = new int[0];
            units = new string[0];
            steps = new string[0];
        }

        public void AddIngredient(string name, int quantity, string unit)
        {
            Array.Resize(ref ingredients, ingredients.Length + 1);
            Array.Resize(ref quantities, quantities.Length + 1);
            Array.Resize(ref units, units.Length + 1);

            int index = ingredients.Length - 1;
            ingredients[index] = name;
            quantities[index] = quantity;
            units[index] = unit;
        }

        public void AddStep(string step)
        {
            Array.Resize(ref steps, steps.Length + 1);
            int index = steps.Length - 1;
            steps[index] = step;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nIngredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{ingredients[i]} - {quantities[i]} {units[i]}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe()
        {
            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
            double factor = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = (int)(quantities[i] * factor);
            }
        }

        public void ResetQuantities()
        {
            
        }

        public void ClearRecipe()
        {
            ingredients = new string[0];
            quantities = new int[0];
            units = new string[0];
            steps = new string[0];
        }
    }
}

