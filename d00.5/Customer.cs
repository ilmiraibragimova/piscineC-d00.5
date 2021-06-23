using System;

namespace d00
{
    public class Customer
    {
        public int number { get; }
        public string name { get; }
        public int cart { get; protected set; }

        public Customer(int number, string name)
        {
            this.number = number;
            this.name = name;
        }
        
        public void fillCart(int capacity)
        {
            var random = new Random();
            cart = random.Next(1, capacity);
        }

        public override string ToString() => $"{number,3} | {name,12}";
        

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Customer p = (Customer)obj;
            return name.Equals(p.name) && number == p.number;
        }
        
        public static bool operator ==(Customer x, Customer y)
        {
            return x.Equals(y);
        }
        
        public static bool operator !=(Customer x, Customer y)
        {
            return !(x == y);
        }

        
    }
}