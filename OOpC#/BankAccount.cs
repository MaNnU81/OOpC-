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
        public int Balance => Transactions.Sum(t => t.Amount);

        public BankAccount(Customer customer, Employee employee, DateTime creationDate, List<Transaction> transactions, int balance)
        {
            Customer = customer;
            EmployeeName = $"{employee.Name} {employee.Surname}"; 
            CreationDate = creationDate;
            Transactions = transactions ?? new List<Transaction>();
           
        }

    }
}
