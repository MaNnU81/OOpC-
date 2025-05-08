using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOpC_
{
    internal class Customer
    {

        public int? Id { get; set; }
        public required string  Name { get; set; }
        public required string Surname { get; set; }
        public required DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public required string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public required string MAilAddress { get; set; }
        public string? Mdp { get; set; }

        public Customer(string name, string surname, DateTime dob, string address, string mAilAddress)
        {
            
            Name = name;
            Surname = surname;
            Dob = dob;
            Address = address;
            MAilAddress = mAilAddress;
            
        }
        public Customer() { }
    }
}
