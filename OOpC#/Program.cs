using static OOpC_.Employee;

namespace OOpC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dob1 = new DateTime(2000, 12, 3);
            var c1 = new Customer("Pippo", "Depippis", dob1, "via Gramsci, Genova 16123, Italy", "pippothereal@topoliniamail.to");
            c1.Mdp = PaymentMethod.Iban;
            var c2 = new Customer("Clarabella", "ManonBellissima", 2001, 05, 06, "via Vannucci, Genova 16123, Italy", "Cl4raBella@topoliniamail.to");
            var c3 = new Customer("Orazio", "Pancrazio", new DateTime(1984, 3, 20), "via Vannucci, Genova 16123, Italy", "Cl4raBella@topoliniamail.to");

            var e1 = new Employee("Paperino", "Paperino", 1980, 3, 25, "Topolinia1");
            e1.Level = ExperienceLevels.Senior;

            //var p1 = new Person("NonEsisto", "PerLaBanca", new DateTime(1984, 3, 20);  non posso crearlo perche Person è abstract


            Console.WriteLine(c1);

            var v1 = new VipCustomer("Topolino", "Mouse", 1990, 1, 25, "via Cantore, Genova 16123, Italy", "topo_lino@topoliniamail.to", 1555);

            List<VipCustomer> vipCustomers = [];
            vipCustomers.Add(v1);
            //vipCustomers.Add(c1);   non si fa, errore customer non vip


            List<Customer> customers = new List<Customer>();
            customers.Add(c1);
            customers.Add(c3);
            customers.Add(v1);

            foreach (var customer in customers)
            {
                //Console.WriteLine(customer.ToString());
                Console.WriteLine(customer.PrintAddress());
            }

            List<Person> persons = new List<Person>();

            persons.Add(e1);
            persons.Add(c2);
            persons.Add(v1);

            foreach (var person in persons)
            {
                Console.WriteLine(person.Wellcome());
            }

        }
    }
}
