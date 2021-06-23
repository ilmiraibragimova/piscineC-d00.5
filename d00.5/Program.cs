using System;
using System.Collections.Generic;
using System.Linq;

namespace d00
{
    class Program
    {
        static void Main(string[] args)
        {
            var cast1 = new Customer(1, "Pete");
            var cast2 = new Customer(1, "Pete");
            Console.WriteLine(cast1.Equals(cast2));
            var cast3 = new Customer(2, "Anne");
            cast1.fillCart(15);
            cast2.fillCart(15);
            cast3.fillCart(15);
            Console.WriteLine(cast1 + " " + cast1.cart);
            Console.WriteLine(cast2 + " " + cast2.cart);
            Console.WriteLine(cast3 + " " + cast3.cart);
            List<Customer> listCusts = new List<Customer>();
            listCusts.Add(new Customer(4, "Dan"));
            listCusts.Add(new Customer(5, "Grace"));
            listCusts.Add(new Customer(6, "Sol"));
            listCusts.Add(new Customer(7, "Pol"));
            listCusts.Add(new Customer(8, "Issy"));
            listCusts.Add(new Customer(9, "Missy"));
            listCusts.Add(new Customer(10, "Okko"));
            listCusts.Add(new Customer(11, "Ono"));
            listCusts.Add(new Customer(12, "Mishell"));
            listCusts.Add(new Customer(13, "Zak"));
            Store store1 = new Store(40, 3);
            int i = 0;
            
            Console.WriteLine("\n    Choosing CashRegister Where Customers Lowest\n");
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine("| {0, 18} | {1,4} | {2,10} | {3,5} | {4,5} |", 
                "Customer", "Cart","CashRegist","Count", "Goods");
            Console.WriteLine("___________________________________________________________");
            while (store1.isOpen() && i < listCusts.Count)
            {
                listCusts[i].fillCart(7);
                store1.starage.quintity -= listCusts[i].cart;
                CashRegister cashRegister = store1.cashRegisters.chooseCashRegisterMinCustomer();
                cashRegister.Customers.Enqueue(listCusts[i]);
                Console.WriteLine("| {0, 15} | {1,4} | {2,10} | {3,5} | {4,5} |",
                    listCusts[i], listCusts[i].cart, cashRegister.Name,
                    cashRegister.Customers.Count, cashRegister.goods);
                                  i++;
            }

            Console.WriteLine("__________________________________________________________");

            Store store2 = new Store(40, 3);
            i = 0;
            Console.WriteLine("\n    Choosing CashRegister Where Goods Lowest\n");
            Console.WriteLine("__________________________________________________________");
            Console.WriteLine("| {0, 17} | {1,4} | {2,10} | {3,5} | {4,5} |", 
                "Customer", "Cart","CashRegist","Count", "Goods");
            Console.WriteLine("__________________________________________________________");
            while (store2.isOpen() && i < listCusts.Count)
            {
                listCusts[i].fillCart(7);
                store2.starage.quintity -= listCusts[i].cart;
                CashRegister cashRegister = store2.cashRegisters.chooseCashRegisterMinCart();
                cashRegister.Customers.Enqueue(listCusts[i]);
                Console.WriteLine("|{0, 15} | {1,4} | {2,10} | {3,5} | {4,5} |",
                    listCusts[i], listCusts[i].cart, cashRegister.Name,
                    cashRegister.Customers.Count, cashRegister.goods);
                i++;
            }

            Console.WriteLine("__________________________________________________________");
        }
    }

    public static class CustomerExtensions
    {
        private static Customer сustomer;
        public static CashRegister chooseCashRegisterMinCustomer(this CashRegister[] cashRegisters)
        {
            int min;
            int length = cashRegisters.Length;
            int[] numCustomers = new int[length];
            int i = 0;
            foreach (var cashRegister in cashRegisters)
            {
                cashRegister.goods = 0;
                numCustomers[i] = cashRegister.Customers.Count;
                Customer[] customersArray = cashRegister.Customers.ToArray();
                foreach (var cust in customersArray)
                {
                    cashRegister.goods += cust.cart;
                    //Console.WriteLine(i + " " + cashRegister.goods);
                }
                //Console.WriteLine();

                i++;
            }

            min = numCustomers.Min();
            int index = Array.IndexOf(numCustomers, min);
            return cashRegisters[index];
        }

       public static CashRegister chooseCashRegisterMinCart(this CashRegister[] cashRegisters)
        {
            int min;
            int length = cashRegisters.Length;
            var numGoods = new int[length];
            int i = 0;
            foreach (var cashRegister in cashRegisters)
            {
                Customer[] customersArray = cashRegister.Customers.ToArray();
                foreach (var cust in customersArray)
                {
                    numGoods[i] += cust.cart;
                }

                i++;
            }

            min = numGoods.Min();
            int index = Array.IndexOf(numGoods, min);
            cashRegisters[index].goods = min;
            return cashRegisters[index];
        }
    }
}
