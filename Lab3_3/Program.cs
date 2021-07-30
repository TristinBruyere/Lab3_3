using System;
using System.Collections.Generic;

namespace Redo3_3
{
    class MenuItem
    {
        public string name;
        public decimal price;
        public int quantity;
        public int Sell(int howMany)
        {
            return quantity -= howMany;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            string addName;
            string removeName;
            string changeName;
            string sellName;
            string changePQ;
            decimal addPrice;
            decimal changePrice;
            int addQuantity;
            int changeQuantity;
            int unitsSold;
            bool keepGoing = true;

            Dictionary<string, MenuItem> menu = new Dictionary<string, MenuItem>();

            MenuItem first = new MenuItem();
            first.name = "Apple";
            first.price = .99m;
            first.quantity = 5;
            menu[first.name] = first;
            MenuItem second = new MenuItem();
            second.name = "Sandwich";
            second.price = 3.99m;
            second.quantity = 7;
            menu[second.name] = second;
            MenuItem third = new MenuItem();
            third.name = "Cheese";
            third.price = 2.99m;
            third.quantity = 10;
            menu[third.name] = third;

            while (keepGoing)
            {
                foreach (var pair in menu)
                {
                    Console.WriteLine($"Item: {pair.Value.name}, Price: ${pair.Value.price}, Quantity: {pair.Value.quantity}");
                }
                do
                {
                    Console.Write("Would you like to (A)dd (R)emove (C)hange (S)ell or (Q)uit: ");
                    choice = Console.ReadLine().ToUpper();
                    if (choice != "A" && choice != "R" && choice != "C" && choice != "S" && choice != "Q")
                    {
                        Console.WriteLine("That is not Valid input, try again.");
                    }
                } while (choice != "A" && choice != "R" && choice != "C" && choice != "S" && choice != "Q");

                switch (choice)
                {
                    case "A": // Adding to the menu
                        while (true)
                        {
                            Console.Write("Enter the name of the item or Q to quit: ");
                            addName = Console.ReadLine();
                            if (menu.ContainsKey(addName))
                            {
                                Console.WriteLine("That item is already on the menu.");
                            }
                            else if (addName == "Q")
                            {
                                break;
                            }
                            else
                            {
                                Console.Write("Enter a price for that item: ");
                                addPrice = decimal.Parse(Console.ReadLine());
                                Console.Write("Enter a quantity for that item: ");
                                addQuantity = Int32.Parse(Console.ReadLine());

                                MenuItem addItem = new MenuItem();
                                addItem.name = addName;
                                addItem.price = addPrice;
                                addItem.quantity = addQuantity;
                                menu[addItem.name] = addItem;
                                Console.WriteLine($"{addName} had been added to the menu.");
                                break;
                            }
                        }
                        break;
                    case "R": // Removing from the menu
                        while (true)
                        {
                            Console.Write("Enter the name of the item you want to remove or enter Q to quit: ");
                            removeName = Console.ReadLine();
                            if (menu.ContainsKey(removeName))
                            {
                                menu.Remove(removeName);
                                Console.WriteLine($"{removeName} has been taken off the menu.");
                                break;
                            }
                            else if (removeName == "Q")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"{removeName} is not on the menu");
                            }
                        }
                        break;
                    case "C": // Changing item on the menu
                        while (true)
                        {
                            Console.Write("Enter the name of the item you want to change or enter Q to quit: ");
                            changeName = Console.ReadLine();
                            if (menu.ContainsKey(changeName))
                            {
                                while (true)
                                {
                                    Console.Write($"Would you like to change the (P)rice or (Q)uantity of {changeName}?: ");
                                    changePQ = Console.ReadLine().ToUpper();
                                    if (changePQ == "Q") // Changing Quantity
                                    {
                                        while (true)
                                        {
                                            Console.Write($"The current quantity of {changeName} is {menu[changeName].quantity}. Enter the new quantity of this item or enter Q to quit: ");
                                            string changeQuantityString = Console.ReadLine().ToUpper();
                                            bool canParse = Int32.TryParse(changeQuantityString, out changeQuantity);
                                            if (canParse)
                                            {
                                                menu[changeName].quantity = changeQuantity;
                                                Console.WriteLine($"The new price of {menu[changeName].name} is {menu[changeName].quantity}");
                                                break;
                                            }
                                            else if (changeQuantityString == "Q")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("That is not valid input.");
                                            }

                                        }
                                        break;
                                    }
                                    else if (changePQ == "P") // Changing Price
                                    {
                                        while (true)
                                        {
                                            Console.Write($"The current price of {changeName} is {menu[changeName].price}. Enter the new price of this item or enter Q to quit: ");
                                            string changePriceString = Console.ReadLine().ToUpper();
                                            bool canParse = decimal.TryParse(changePriceString, out changePrice);
                                            if (canParse)
                                            {
                                                menu[changeName].price = changePrice;
                                                Console.WriteLine($"The new price of {menu[changeName].name} is {menu[changeName].price}");
                                                break;
                                            }
                                            else if (changePriceString == "Q")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("That is not valid input.");
                                            }

                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("That is not valid input.");
                                    }
                                }
                                break;
                            }
                            else if (changeName == "Q")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That item is not on the menu.");
                            }
                        }
                        break;
                    case "S": // Selling menu item
                        while (true)
                        {
                            Console.Write("Enter the name of the item you want to sell or enter Q to quit: ");
                            sellName = Console.ReadLine();
                            if (menu.ContainsKey(sellName))
                            {
                                while (true)
                                {
                                    Console.Write("Enter how many units are being sold or enter Q to quit: ");
                                    string unitsSoldString = Console.ReadLine().ToUpper();
                                    bool canParse = Int32.TryParse(unitsSoldString, out unitsSold);
                                    if (canParse && unitsSold <= menu[sellName].quantity)
                                    {
                                        menu[sellName].Sell(unitsSold);
                                        break;
                                    }
                                    else if (canParse && unitsSold > menu[sellName].quantity)
                                    {
                                        Console.WriteLine("You do not have that many units to sell.");
                                    }
                                    else if (unitsSoldString == "Q")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("That is not valid input.");
                                    }
                                }
                                break;
                            }
                            else if (sellName == "Q")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That item is not on the menu.");
                            }
                        }
                        break;
                    default: // Quit
                        keepGoing = false;
                        break;
                }
            }

            Console.WriteLine("\nGood bye!");

        }
    }
}
