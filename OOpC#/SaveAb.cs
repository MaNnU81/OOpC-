using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OOpC_
{
    internal class SaveAb : BankAccount
    {

        public SaveAb(Customer customer, Employee employee, int year, int month, int day,
           List<Transaction> transactions, decimal initialBalance = 0)
    : base(customer, employee, year, month, day, transactions, initialBalance)
        {
        }

        public override void BankingMovement()
        {
            base.BankingMovement(); 

            var lastTransaction = Transactions.LastOrDefault();
            if (lastTransaction?.Amount < 0)
            {
                decimal Tax = Math.Abs(lastTransaction.Amount) * -0.03m;
                Transactions.Add(new Transaction(Tax));
                Console.WriteLine($"Interesse di {Tax:C} addebitato!" + " " + "Saldo residuo: " + " " + Balance + "\n------END---------- ");
            }
            else
            {
                decimal Bonus = Math.Abs(lastTransaction.Amount) * 0.02m;
                Transactions.Add(new Transaction(Bonus));
                Console.WriteLine($"Bonus di {Bonus:C} accreditato!" + " " + "Saldo residuo: " + " " + Balance + "\n------END---------- ");
            }
        }
    }
}

