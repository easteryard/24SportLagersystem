using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Customer
    {
        //her har vi vores properties
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int PhoneNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        //dette er vores default konstruktør
        public Customer()
        {

        }

        //dette er vores konstruktør som initialisere vores properties
        public Customer(int customerId, string name, int phoneNo, string address, string email)
        {
            CustomerId = customerId;
            Name = name;
            PhoneNo = phoneNo;
            Address = address;
            Email = email;
        }

        //dette er vores tostring som gør det muligt at udksrive vores properties
        public override string ToString()
        {
            return $"{nameof(CustomerId)}: {CustomerId}, {nameof(Name)}: {Name}, {nameof(PhoneNo)}: {PhoneNo}, {nameof(Address)}: {Address}, {nameof(Email)}: {Email}";
        }
    }
}
