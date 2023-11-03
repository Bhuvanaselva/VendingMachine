// See https://aka.ms/new-console-template for more information

using VendingMachine;

VendingMachineService vendingMachine = new VendingMachineService();

Console.WriteLine("----------Vending Machine----------\n");

while (true)
{

    Console.WriteLine("\n Menu:");
    Console.WriteLine("--------");
    Console.WriteLine("1. Insert Money");
    Console.WriteLine("2. Show All Products");
    Console.WriteLine("3. Buy a Product");
    Console.WriteLine("4. End Transaction");
    Console.WriteLine("5. Exit");

    Console.Write("\nEnter your choice: ");
    if (int.TryParse(Console.ReadLine(), out int choice))
    {

        switch (choice)
        {
            case 1:
                Console.Write("\nEnter denomination (1/5/10/20/50/100/500/1000 kr): ");
                int denomination = int.Parse(Console.ReadLine());
                vendingMachine.InsertMoney(denomination);
            
                break;

            case 2:
                Console.WriteLine("\nAvailable Products:");
                Console.WriteLine("--------------------\n");
                foreach (string productInfo in vendingMachine.ShowAll())
                {
                    Console.WriteLine(productInfo);
                }
                break;

            case 3:

                Console.Write("\nEnter the product ID to purchase: ");
                int productId = int.Parse(Console.ReadLine());
                try
                {
                    vendingMachine.Purchase(productId);
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                break;  
                
            case 4:
                Dictionary<int, int> change = vendingMachine.EndTransaction();
                Console.WriteLine("\nTransaction Ended. Change returned:");
                foreach (var item in change)
                {
                    Console.WriteLine($"{item.Value} x {item.Key} kr");
                }
                Console.WriteLine("\nThank you !!");
                break;

            case 5:
                return;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid option.");
    }
}