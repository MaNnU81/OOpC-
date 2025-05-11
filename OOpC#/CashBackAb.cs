using OOpC_;

internal class CashBackAb : BankAccount
{
    // Costruttore allineato con BankAccount
    public CashBackAb(Customer customer, Employee employee, int year, int month, int day,
                List<Transaction> transactions, decimal initialBalance = 0)
     : base(customer, employee, year, month, day, transactions, initialBalance)
    {
    }

    public override void BankingMovement()
    {
        base.BankingMovement(); // Esegui la logica base

        var lastTransaction = Transactions.LastOrDefault();
        if (lastTransaction?.Amount < 0)
        {
            decimal cashbackAmount = Math.Abs(lastTransaction.Amount) * 0.05m;
            Transactions.Add(new Transaction(cashbackAmount));
            Console.WriteLine($"CashBack di {cashbackAmount:C} accreditato!" + " " + "Saldo residuo: " + " " + Balance + "\n------END---------- ");
        }
    }
}