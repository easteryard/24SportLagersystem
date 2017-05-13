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
        public int OrderLineId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public override string ToString()
        {
            return $"{nameof(OrderLineId)}: {OrderLineId}, {nameof(OrderId)}: {OrderId}, {nameof(ProductId)}: {ProductId}, {nameof(Amount)}: {Amount}, {nameof(Order)}: {Order}, {nameof(Product)}: {Product}";
        }
    }
}
