using _01_RepositoryCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ConsoleCafe
{
    public class ProgramUI
    {
        public CafeRepository _cafeRepo = new CafeRepository();
        public void Run()
        {
            SeedCafe();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Cafe! LETTUCE change your mood with food!\n" +
                    "\n" +
                    "Please choose one of the options below.\n" +
                    "\n" +
                    "1. Show a list of meal options.\n" +
                    "2. Add an item to the menu.\n" +
                    "3. Remove an item from the menu.\n" +
                    "4. Exit\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        MealOptions();
                        break;
                    case "2":
                        AddItems();
                        break;
                    case "3":
                        RemoveItems();
                        break;
                    case "4":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry. Please enter a valid number.");
                        break;
                }
            }
        }

        public void MealOptions()
        {
            Console.Clear();
            List<Menu> MealList = _cafeRepo.ListOrders();

            foreach (Menu content in MealList)
            {
                Console.WriteLine($"#{content.MealNumber}\n" +
                    $"{content.MealName}\n" +
                    $"{content.Description}\n" +
                    $"{content.Ingredients}\n" +
                    $"{content.Price}\n");
            }

            Console.WriteLine("Press 'Enter' to return to the Main Menu.");
            Console.ReadLine();
        }

        public void AddItems()
        {
            Menu content = new Menu();

            Console.Clear();
            Console.WriteLine("(MealNumber) (MealName) (Description) (Ingredients) (Price)\n");

            Console.WriteLine("Enter the new meal number: ");
            content.MealNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.MealNumber}) (MealName) (Description) (Ingredients) (Price)\n");

            Console.WriteLine("Enter the new meal name: ");
            content.MealName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.MealNumber}) ({content.MealName}) (Description) (Ingredients) (Price)\n");

            Console.WriteLine($"Enter a description for {content.MealName}: ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.MealNumber}) ({content.MealName}) ({content.Description}) (Ingredients) (Price)");

            Console.WriteLine($"Enter the ingredients for {content.MealName}: ");
            content.Ingredients = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.MealNumber}) ({content.MealName}) ({content.Description}) ({content.Ingredients}) (Price)");

            Console.WriteLine($"Enter the price for {content.MealName}: ");
            content.Price = double.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.MealNumber}) ({content.MealName}) ({content.Description}) ({content.Ingredients}) ({content.Price})");

            Console.WriteLine("Order Summary:\n");

            Console.WriteLine($"MealNumber: {content.MealNumber}\n" +
                $"MealName: {content.MealName}\n" +
                $"Description: {content.Description}\n" +
                $"Ingredients: {content.Ingredients}\n" +
                $"Price: {content.Price}\n");

            Console.WriteLine("Press 'Enter' to confirm order.");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Order was successfully added!\n" +
                "Press 'Enter' to return to the Main Menu.");
            Console.ReadLine();

            _cafeRepo.AddItems(content);
        }

        public void RemoveItems()
        {
            Console.WriteLine("Which order would you like to remove?\n" +
                "(Choosse meal number)");

            List<Menu> MealList = _cafeRepo.ListOrders();

            foreach (Menu order in MealList)
            {
                Console.WriteLine($"#{order.MealNumber} - {order.MealName}\n");
            }

            int numRemove = int.Parse(Console.ReadLine());

            Menu Object = _cafeRepo.FindOrderByID(numRemove);

            _cafeRepo.RemoveItems(Object);

            Console.WriteLine("Order was successfully removed!\n" +
                "Press 'Enter' to return to the Main Menu.");
            Console.ReadLine();
        }

        public void SeedCafe()
        {
            Menu hamburgerMeal = new Menu(1, "Hamburger Meal", "Juicy Burger Loaded with all your Fixings", "8 oz Angus Beef Patty with Lettuce, Tomato, Ketchup & Mustard; French Fries; 20 oz Soft Drink", 10.99);
            Menu hotDogMeal = new Menu(2, "Hot Dog Meal", "Jumbo, all Beef Hot Dog", "Ketchup, Mustard & Relish; French Fries; 20 oz Soft Drink", 6.99);
            Menu pizzaMeal = new Menu(3, "Pizza Slice Meal", "Three-Meats, Stone-Baked Pizza Pie", "Pepperoni, Italian Sausage, & Ham; 2 Breadsticks; 20 oz Soft Drink", 7.99);
            Menu soupMeal = new Menu(4, "Soup Meal", "The Best Cheesy Potato Soup in Town", "Potatoes, Cheese, & Bacon Bits; 20 oz Soft Drink", 3.99);
            Menu saladMeal = new Menu(5, "Salad Meal", "Made with Fresh Ingredients and Hand-Chopped Daily", "Romaine Lettuce, Eggs, Croutons, Bacon Bits, Cheese & Tomatoes; 20 oz Soft Drink", 5.99);

            _cafeRepo.AddItems(hamburgerMeal);
            _cafeRepo.AddItems(hotDogMeal);
            _cafeRepo.AddItems(pizzaMeal);
            _cafeRepo.AddItems(soupMeal);
            _cafeRepo.AddItems(saladMeal);
        }
    }
}
