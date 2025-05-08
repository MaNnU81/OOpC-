using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOpC_
{
    internal class Customer: Person
    {
        public  string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public  string MAilAddress { get; set; }
        public PaymentMethod? Mdp { get; set; }

        public Customer(string name, string surname, DateTime dob, string address, string mAilAddress): base(name, surname, dob.Year, dob.Month, dob.Day )
        {
           
            Address = address;
            MAilAddress = mAilAddress;
            
        }




        public Customer(string name, string surname, int year, int month, int day, string address, string mAilAddress): base(name, surname, year, month, day)
        {

            Address = address;
            MAilAddress = mAilAddress;

        }
        //public Customer() { }

        public override string ToString()
        {
            return "Cliente: " + " " + base.ToString();
        }

        public override string Wellcome()
        {
            return "Benvenuto!";
        } 

        public virtual string PrintAddress()
        {
            return Name + " " +Surname + "\n" +  Address.Replace(", ", "\n") + "\n --------------";
        }
    }

    public enum PaymentMethod
    {
        Iban,
        Cdc,
        Cash
    }
}
