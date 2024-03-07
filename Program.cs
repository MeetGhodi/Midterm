using System;

public class InventoryItem
{
    // Properties
    public string ItemName { get; private set; }
    public int ItemId { get; private set; }
    public decimal Price { get; private set; }
    public int QuantityInStock { get; private set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, decimal price, int quantityInStock)
    {
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(decimal newPrice)
    {
        Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public bool SellItem(int quantitySold)
    {
        if (QuantityInStock >= quantitySold)
        {
            QuantityInStock -= quantitySold;
            return true; // Indicating the item has been successfully sold
        }
        else
        {
            Console.WriteLine($"Error: Insufficient stock. Available quantity: {QuantityInStock}");
            return false; // Indicating the sale was unsuccessful due to insufficient stock
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine($"Item Name: {ItemName}, Item ID: {ItemId}, Price: ${Price}, Quantity in Stock: {QuantityInStock}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter item name:");
        string itemName = Console.ReadLine();

        Console.WriteLine("Enter item ID:");
        int itemId;
        while (!int.TryParse(Console.ReadLine(), out itemId))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for item ID:");
        }

        Console.WriteLine("Enter price:");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input. Please enter a valid decimal for price:");
        }

        Console.WriteLine("Enter quantity in stock:");
        int quantityInStock;
        while (!int.TryParse(Console.ReadLine(), out quantityInStock))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for quantity in stock:");
        }

        InventoryItem item = new InventoryItem(itemName, itemId, price, quantityInStock);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Print item details");
            Console.WriteLine("2. Sell item");
            Console.WriteLine("3. Restock item");
            Console.WriteLine("4. Check if item is in stock");
            Console.WriteLine("5. Update price");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    item.PrintDetails();
                    break;
                case "2":
                    Console.WriteLine("Enter quantity to sell:");
                    int quantitySold;
                    while (!int.TryParse(Console.ReadLine(), out quantitySold))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for quantity to sell:");
                    }
                    bool success = item.SellItem(quantitySold);
                    if (success)
                    {
                        Console.WriteLine("Item sold.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter additional quantity to restock:");
                    int additionalQuantity;
                    while (!int.TryParse(Console.ReadLine(), out additionalQuantity))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for additional quantity:");
                    }
                    item.RestockItem(additionalQuantity);
                    Console.WriteLine("Item restocked.");
                    break;
                case "4":
                    Console.WriteLine($"{item.ItemName} is {(item.IsInStock() ? "in stock" : "not in stock")}, Quantity in Stock: {item.QuantityInStock}.");
                    break;
                case "5":
                    Console.WriteLine("Enter new price:");
                    decimal newPrice;
                    while (!decimal.TryParse(Console.ReadLine(), out newPrice))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid decimal for new price:");
                    }
                    item.UpdatePrice(newPrice);
                    Console.WriteLine("Price updated.");
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
