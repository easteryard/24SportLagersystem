using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int PhoneNr { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Customer(int customerId, string name, int phoneNr, string address, string email)
        {
            CustomerId = customerId;
            Name = name;
            PhoneNr = phoneNr;
            Address = address;
            Email = email;
        }

        public Customer()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(CustomerId)}: {CustomerId}, {nameof(Name)}: {Name}, {nameof(PhoneNr)}: {PhoneNr}, {nameof(Address)}: {Address}, {nameof(Email)}: {Email}";
        }
    }
}
