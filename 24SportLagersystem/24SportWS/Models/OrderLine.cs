namespace _24SportWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderLine")]
    public partial class OrderLine
    {
        [Key]
        public int OrderLine_Id { get; set; }

        public int Order_Id { get; set; }

        public int Product_Id { get; set; }

        public int Amount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public override string ToString()
        {
            return $"{nameof(OrderLine_Id)}: {OrderLine_Id}, {nameof(Order_Id)}: {Order_Id}, {nameof(Product_Id)}: {Product_Id}, {nameof(Amount)}: {Amount}, {nameof(Order)}: {Order}, {nameof(Product)}: {Product}";
        }
    }
}
