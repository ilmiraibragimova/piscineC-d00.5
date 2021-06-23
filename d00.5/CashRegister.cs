using System.Collections.Generic;

namespace d00
{
    public class CashRegister
    {
        public string Name { get; }
        public Queue<Customer> Customers = new ();
        public int goods { get; set; }
        
        public CashRegister(string name)
        {
            Name = name;
        }
        
        public override string ToString() =>
            Name;

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            CashRegister p = (CashRegister)obj;
            return Name.Equals(p.Name) ;
        }
        
        public static bool operator ==(CashRegister x, CashRegister y)
        {
            return x.Equals(y);
        }                               
        
        public static bool operator !=(CashRegister x, CashRegister y)
        {
            return !(x == y);
        }

    }
    
    
}