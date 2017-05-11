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
        public int PhoneNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Customer()
        {

        }

        public Customer(int customerId, string name, int phoneNo, string address, string email)
        {
            CustomerId = customerId;
            Name = name;
            PhoneNo = phoneNo;
            Address = address;
            Email = email;
        }

        public override string ToString()
        {
            return $"{nameof(CustomerId)}: {CustomerId}, {nameof(Name)}: {Name}, {nameof(PhoneNo)}: {PhoneNo}, {nameof(Address)}: {Address}, {nameof(Email)}: {Email}";
        }
    }
}
