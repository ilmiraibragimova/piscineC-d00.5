namespace d00
{
    public class Store
    {
        public Starage starage { get;  }
        public CashRegister[] cashRegisters { get; }

        public Store(int value, int numberCashRegister)
        {
            starage = new Starage(value);
            cashRegisters = new CashRegister[numberCashRegister];
            for (int i = 0; i < numberCashRegister; i++)
            {
                cashRegisters[i] = new CashRegister((i + 1).ToString());
            } 
        }

        public bool isOpen() => !starage.isEmpty();
    }
}