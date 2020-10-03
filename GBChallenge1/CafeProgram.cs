using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBChallenge1
{
    public class CafeProgram
    {
        static void Main(string[] args)
        {
            /*Create a Menu Class with properties, constructors, and fields.
            Create a MenuRepository Class that has methods needed.
            Create a Test Project for your repository methods. (You don't need to test your constructors or objects, just your methods)
            Create a ProgramUI file that allows the cafe manager to add, delete, and see all items in the menu list.*/

            GBC1Program cafe = new GBC1Program();
            cafe.Run();
        }

        class GBC1Program
        {
            private readonly menuRepository _menuRepo = new menuRepository();
            public void Run()
            {
                SeedContent();
                RunMenu();
            }

            public void SeedContent()
            {

                Menu BBQChicken = new Menu(
                    1,
                    "BBQ Chicken",
                    "Chicken covered in BBQ sauce",
                    "Chicken, BBQ Sauce", 8.99);
               

                _menuRepo.AddItemToDirecotry(BBQChicken);
            }

            public void RunMenu()
            {
                //Create a ProgramUI file that allows the cafe manager to add, delete, and see all items in the menu list.
                bool programIsRunning = true;
                while (programIsRunning)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the number of the options you'd like to select:\n" +
                            "1. Add new Menu item\n" +
                            "2. Show all menu items\n" +
                            "3. Remove Menu item\n" +
                            "4. Exit");
                    string response = Console.ReadLine();
                    switch (response)
                    {
                        case "1":
                            AddToMenu();
                            break;
                        case "2":
                            ShowMenu();
                            break;
                        case "3":
                            RemoveFromMenu();
                            break;
                        case "4":
                            Console.WriteLine("GoodBye.");
                            Console.ReadKey();
                            programIsRunning = false;
                            break;
                        default:
                            break;


                    }
                }
            }
            public void AddToMenu()
            {
                Console.Clear();
                Console.WriteLine("Add new menu item name:");
                string name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"What is the {name} menu number?");
                int itemNumber = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine($"What is the description for {name}?");
                string description = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"What are the ingredents for {name}?");
                string ingredents = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"How much is {name}?");
                double price = Double.Parse(Console.ReadLine());

                Menu newitem = new Menu(itemNumber, name, description, ingredents, price);

                bool itemWasAdded = _menuRepo.AddItemToDirecotry(newitem);

                if (itemWasAdded)
                {
                    Console.WriteLine($"{name} was added to the menu.");

                }
                else
                {
                    Console.WriteLine("Please try again.");

                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
            public void RemoveFromMenu()
            {

                Console.Clear();
                Console.WriteLine("What is the name of the item you wish to remove?");
                string name = Console.ReadLine();
                _menuRepo.RemoveItemFromMenu(name);
            }
            public void ShowMenu()
            {
                Console.Clear();

                List<Menu> items = _menuRepo.MenuContent();
                foreach (Menu item in items)
                {
                    Console.WriteLine($"{item.ItemNumber}. {item.Name} - ${item.Price}\n" +
                        $"{item.Description}.\n" +
                        $"{item.Ingredients}.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
    public class Menu
    {
        /*A meal number, so customers can say "I'll have the #5"
            A meal name
            A description
            A list of ingredients,
            A price */

        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public Menu() { }
        public Menu(
            int itemNumber,
            string name,
            string desctription,
            string ingredients,
            double price)
        {
            ItemNumber = itemNumber;
            Name = name;
            Description = desctription;
            Ingredients = ingredients;
            Price = price;
        }
    }
    public class menuRepository
    {
        protected List<Menu> _menuDirectory = new List<Menu>();

        public bool AddItemToDirecotry(Menu item)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(item);

            bool wasAdded = (_menuDirectory.Count > startingCount);
            return wasAdded;
        }

        public List<Menu> MenuContent()
        {
            return _menuDirectory;
        }

        public bool RemoveItemFromMenu(string name)
        {
            int startingCount = _menuDirectory.Count;

            int index = -1;
            foreach (Menu item in _menuDirectory)
            {
                if (item.Name == name)
                {
                    index = _menuDirectory.IndexOf(item);
                }
            }
            if (index != -1)
            {

                _menuDirectory.RemoveAt(index);
            }

            bool wasRemoved = (_menuDirectory.Count < startingCount);
            return wasRemoved;
        }
    }
}
