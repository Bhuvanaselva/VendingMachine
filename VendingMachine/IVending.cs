using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    interface IVending
    {
        void Purchase(int productId);
        List<string> ShowAll();
  
        void InsertMoney(int denomination);
        Dictionary<int, int> EndTransaction();
    }

    class VendingMachineService : IVending
    {
        private readonly int[] validDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        private int moneyPool = 0;
        private List<Product> products = new List<Product>();

        public VendingMachineService()
        {
            products.Add(new Drink(1, "Coke",   25, 250));
            products.Add(new Snack(2, "Chips",  20, "Creamy"));
            products.Add(new Candy(3, "Kinder", 10, true));
        }

        public void InsertMoney(int denomination)
        {
            if (Array.IndexOf(validDenominations, denomination) != -1)
            {
                moneyPool += denomination;
                Console.WriteLine($"\nYou've inserted {denomination} kr.\n\nTotal money in the pool: {moneyPool} kr");
            }
            else
            {
                Console.WriteLine("Invalid denomination. Please insert valid currency.");
            }
        }

        public List<string> ShowAll()
        {
            List<string> productInfo = new List<string>();
            foreach (var product in products)
            {
                productInfo.Add($"{product.Id} - {product.Name}, Cost: {product.Cost} kr");
            }
            return productInfo;
        }

        public void Purchase(int productId)
        {
            Product product = products.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                if (moneyPool >= product.Cost)
                {
                    moneyPool -= product.Cost;
                    Console.WriteLine($"\nYou have purchased: {product.Name}.");
                    Console.WriteLine(product.Use());
                    products.Remove(product);
                }
                else
                {
                    Console.WriteLine("Not enough money to purchase this product.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product ID. Please enter a valid ID.");
            }
        }

        public Dictionary<int, int> EndTransaction()
        {
            Dictionary<int, int> change = new Dictionary<int, int>();
            int[] denominationValues = { 1000, 500, 100, 50, 20, 10, 5, 1 };

            foreach (int denomination in denominationValues)
            {
                if (moneyPool >= denomination)
                {
                    int count = moneyPool / denomination;
                    moneyPool %= denomination;
                    if (count > 0)
                    {
                        change.Add(denomination, count);
                    }
                }
            }
            moneyPool = 0;
            return change;
        }
    }
}




