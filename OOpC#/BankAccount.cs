using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OOpC_
{
    internal class BankAccount
    {

        public Customer Customer { get; set; }  // Oggetto completo (puoi accedere a tutti i dati, magari in futuro per anagrafica)
        public string EmployeeName { get; }     // Solo nome e cognome (read-only)
        public DateTime CreationDate { get; set; }
        public List<Transaction> Transactions { get; set; }
        private decimal _initialBalance; // Saldo iniziale
        public decimal Balance => _initialBalance + Transactions.Sum(t => t.Amount);

        public BankAccount(Customer customer, Employee employee, int year, int month, int day, List<Transaction> transactions, decimal initialBalance = 1000)
        {
            _initialBalance = initialBalance;
            Customer = customer;
            EmployeeName = $"{employee.Name} {employee.Surname}";
            CreationDate = new DateTime(year, month, day);
            Transactions = transactions ?? new List<Transaction>();
            

        }

        public override string ToString()
        {
            return "Nome Cliente: " + " " + Customer.Name + " " + Customer.Surname + "\n" + "Creato da: " + " " + EmployeeName + "\n" + "Creato il: " + " " + CreationDate + "\n" + "Saldo residuo: " + " " + Balance + "\n---------------- ";
        }

        public virtual  void BankingMovement()
        {
            decimal numeroIput;
            bool inputValido = false;

            while (!inputValido)
            {
                Console.Write("Inserisci la cifra depositata/prelevata (usa . per decimali): \"");
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out numeroIput))
                {
                    Console.WriteLine("-----ERRORE: Devi inserire una cifra valida!-----");
                    continue;
                }

                inputValido = true;

                if (numeroIput > 0)
                {
                    Console.WriteLine("Nome Cliente: " + " " + Customer.Name + " " + Customer.Surname + "\n" + "Saldo residuo: " + " " + Balance + "\n---------------- ");
                    Transactions.Add(new Transaction(numeroIput));
                    Console.WriteLine($"Deposito di {numeroIput:C} effettuato. Nuovo saldo: {Balance:C}\n" +
                        $"Ultime transazioni:\n{string.Join("\n", Transactions
                     .OrderByDescending(t => t.OperationDate)
                     .Take(3)
                     .Select(t => $"{t.OperationDate:dd/MM/yy HH:mm}  {t.Amount:C}"))}");

                }
                else if (numeroIput < 0)
                {
                    decimal importoPrelievo = Math.Abs(numeroIput);
                    if (importoPrelievo <= Balance)
                    {
                        Console.WriteLine("Nome Cliente: " + " " + Customer.Name + " " + Customer.Surname + "\n" + "Saldo residuo: " + " " + Balance + "\n---------------- ");
                        Transactions.Add(new Transaction(numeroIput));
                        Console.WriteLine($"Prelievo di {importoPrelievo:C} effettuato. Nuovo saldo: {Balance:C}\n" +
                        $"Ultime transazioni:\n{string.Join("\n", Transactions
                     .OrderByDescending(t => t.OperationDate)
                     .Take(3)
                     .Select(t => $"{t.OperationDate:dd/MM/yy HH:mm}  {t.Amount:C}"))}");
                    }
                }
                else
                {
                    Console.WriteLine("-----SALDO INSUFFICIENTE!-----");

                }
            } 
        }
    }
}
