namespace _24SportWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? PhoneNo { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{nameof(CustomerId)}: {CustomerId}, {nameof(Name)}: {Name}, {nameof(PhoneNo)}: {PhoneNo}, {nameof(Address)}: {Address}, {nameof(Email)}: {Email}";
        }
    }
}
