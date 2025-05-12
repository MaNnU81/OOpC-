using System.Transactions;
using static OOpC_.Employee;



namespace OOpC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DateTime dob1 = new DateTime(2000, 12, 3);
            var c1 = new Customer("Pippo", "Depippis", dob1, "via Gramsci, Genova 16123, Italy", "pippothereal@topoliniamail.to");
            c1.Mdp = PaymentMethod.Iban;
            var c2 = new Customer("Clarabella", "ManonBellissima", 2001, 05, 06, "via Vannucci, Genova 16123, Italy", "Cl4raBella@topoliniamail.to");
            var c3 = new Customer("Orazio", "Pancrazio", new DateTime(1984, 3, 20), "via Vannucci, Genova 16123, Italy", "Cl4raBella@topoliniamail.to");

            var e1 = new Employee("Paperino", "Paperino", 1980, 3, 25, "Topolinia1");
            e1.Level = ExperienceLevels.Senior;

            //var p1 = new Person("NonEsisto", "PerLaBanca", new DateTime(1984, 3, 20);  non posso crearlo perche Person è abstract


            //Console.WriteLine(c1);

            var v1 = new VipCustomer("Topolino", "Mouse", 1990, 1, 25, "via Cantore, Genova 16123, Italy", "topo_lino@topoliniamail.to", 1555);

            List<VipCustomer> vipCustomers = [];
            vipCustomers.Add(v1);
            //vipCustomers.Add(c1);   non si fa, errore customer non vip


            List<Customer> customers = new List<Customer>();
            customers.Add(c1);
            customers.Add(c3);
            customers.Add(v1);

            //foreach (var customer in customers)
            //{
            //    //Console.WriteLine(customer.ToString());
            //    Console.WriteLine(customer.PrintAddress());
            //}

            List<Person> persons = new List<Person>();

            persons.Add(e1);
            persons.Add(c2);
            persons.Add(v1);

            //foreach (var person in persons)
            //{
            //    Console.WriteLine(person.Wellcome());
            //}


            var t1 = new Transaction(2000);
            var t2 = new Transaction(-200);
            var t3 = new Transaction(2000);
            var ab1 = new BankAccount(c1, e1, 2022, 02, 20, new List<Transaction>(), 20000);
            var ab2 = new CashBackAb(c2, e1, 2018, 04, 20, new List<Transaction>(), 15000);
            var ab3 = new SaveAb(c3, e1, 2018, 06, 21, new List<Transaction>(), 10550);

            List<BankAccount> bankaccounts = new List<BankAccount>();
            bankaccounts.Add(ab1);
            bankaccounts.Add(ab2);
            bankaccounts.Add(ab3);

            foreach (var bankaccount in bankaccounts)
            {
                Console.WriteLine(bankaccount.ToString());
            }



            BankAccount accountDiProva = ab1;
            BankAccount CashBackAccount = ab2;
            BankAccount SaveAccount = ab3;

            //attiva per provare funzione BaseAccount
            //accountDiProva.BankingMovement();

            //attiva per provare funzione CashBackAccount
            CashBackAccount.BankingMovement();

            //attiva per provare funzione SaveAb
            /*SaveAccount.BankingMovement()*/;
        }
    }
}





//////////////////////////////////////////////////
///////////////////////VERSIONE 2.0//////////////////////////


//using System;
//using System.Collections.Generic;
//using System.Transactions;

//namespace OOpC_
//{
//    internal class Program
//    {
//        private static void EseguiOperazioni(BankAccount account)
//        {
//            while (true)
//            {
//                Console.WriteLine("\nOperazioni disponibili:");
//                Console.WriteLine("1 - Deposito/Prelievo");
//                Console.WriteLine("2 - Visualizza saldo");
//                Console.WriteLine("3 - Visualizza storico");
//                Console.WriteLine("4 - Esci");
//                Console.Write("Scelta: ");

//                var scelta = Console.ReadLine();

//                switch (scelta)
//                {
//                    case "1":
//                        Console.Clear();
//                        account.BankingMovement();
//                        break;
//                    case "2":
//                        Console.Clear();
//                        Console.WriteLine($"\nSaldo attuale: {account.Balance:C}");
//                        break;
//                    case "3":
//                        Console.Clear();
//                        Console.WriteLine(account.ToString());
//                        break;
//                    case "4":
//                        return;
//                    default:
//                        Console.WriteLine("Scelta non valida!");
//                        break;
//                }
//            }
//        }

//        static void Main(string[] args)
//        {
//            Console.OutputEncoding = System.Text.Encoding.UTF8;

//            // Inizializzazione dati
//            DateTime dob1 = new DateTime(2000, 12, 3);
//            var c1 = new Customer("Pippo", "Depippis", dob1, "via Gramsci, Genova 16123, Italy", "pippothereal@topoliniamail.to");
//            var c2 = new Customer("Clarabella", "ManonBellissima", 2001, 05, 06, "via Vannucci, Genova 16123, Italy", "Cl4raBella@topoliniamail.to");
//            var c3 = new Customer("Orazio", "Pancrazio", new DateTime(1984, 3, 20), "via Vannucci, Genova 16123, Italy", "Cl4raBella@topoliniamail.to");

//            var e1 = new Employee("Paperino", "Paperino", 1980, 3, 25, "Topolinia1");
//            var v1 = new VipCustomer("Topolino", "Mouse", 1990, 1, 25, "via Cantore, Genova 16123, Italy", "topo_lino@topoliniamail.to", 1555);

//            // Creazione account con saldo iniziale
//            var ab1 = new BankAccount(c1, e1, 2022, 02, 20, new List<Transaction>(), 2500);
//            var ab2 = new CashBackAb(c2, e1, 2018, 04, 20, new List<Transaction>(), 200);
//            var ab3 = new SaveAb(c3, e1, 2018, 06, 21, new List<Transaction>(), 1000);

//            // Modifica i costruttori delle classi derivate per supportare initialBalance
//            List<BankAccount> bankaccounts = new List<BankAccount> { ab1, ab2, ab3 };

//            Console.WriteLine("=== BENVENUTO NEL SISTEMA BANCARIO ===");
//            Console.WriteLine("Seleziona l'account da utilizzare:");

//            for (int i = 0; i < bankaccounts.Count; i++)
//            {
//                Console.WriteLine($"{i + 1} - {bankaccounts[i].Customer.Name} {bankaccounts[i].Customer.Surname}");
//            }

//            Console.Write("Scelta: ");
//            if (int.TryParse(Console.ReadLine(), out int sceltaAccount) && sceltaAccount > 0 && sceltaAccount <= bankaccounts.Count)
//            {
//                Console.Clear();
//                Console.WriteLine($"Account selezionato: {bankaccounts[sceltaAccount - 1].Customer.Name}");
//                EseguiOperazioni(bankaccounts[sceltaAccount - 1]);
//            }
//            else
//            {
//                Console.WriteLine("Selezione non valida!");
//            }

//            Console.WriteLine("\nProgramma terminato. Premere un tasto per uscire...");
//            Console.ReadKey();
//        }
//    }
//}
