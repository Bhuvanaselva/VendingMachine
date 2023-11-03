using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine
{
     public abstract class Product
    {
        public int Id { get; }
        public string Name { get; }
        public int Cost { get; }

        public Product(int id, string name, int cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

        public abstract string Examine();
        public abstract string Use();
    }
    class Drink : Product
    {
        public int Volume{ get; }

        public Drink(int id, string name, int cost, int volume) : base(id, name, cost)
        {
            Volume = volume;
        }

        public override string Examine()
        {
            return $"\nDrink: {Name},Cost: {Cost} kr, Volume:{Volume}ml";
        }

        public override string Use()
        {
            return $"\nEnjoy your {Name} drink!";
        }
    }

    class Snack : Product
    {
        public string Flavour { get; }

        public Snack(int id, string name, int cost, string flavour) : base(id, name, cost)
        {
            Flavour = flavour;
        }

        public override string Examine()
        {
            return $"\nSnack: {Name}, Flavour: {Flavour}, Cost: {Cost} kr";
        }

        public override string Use()
        {
            return $"\nEat your {Flavour} {Name}! ";
        }
    }

    class Candy : Product
    {
        public bool IsSugarFree { get; }

        public Candy(int id, string name, int cost, bool isSugarFree) : base(id, name, cost)
        {
            IsSugarFree = isSugarFree;
        }

        public override string Examine()
        {
            return $"\n{Name}, Cost: {Cost} kr, Sugar-Free: {IsSugarFree}";
        }

        public override string Use()
        {
            return $"\nEnjoy the {Name} candy!";
        }
    }
}