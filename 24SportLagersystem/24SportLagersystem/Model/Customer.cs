using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public int PhoneNr { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }


        public Customer()
        {

        }

        public Customer(string name, int customerId, int phoneNr, string address, string email)
        {
            Name = name;
            CustomerId = customerId;
            PhoneNr = phoneNr;
            Address = address;
            Email = email;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(CustomerId)}: {CustomerId}, {nameof(PhoneNr)}: {PhoneNr}, {nameof(Address)}: {Address}, {nameof(Email)}: {Email}";
        }
    }
}
