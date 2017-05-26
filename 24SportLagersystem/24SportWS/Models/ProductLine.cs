namespace _24SportWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductLine")]
    public partial class ProductLine
    {
        public int ProductLineId { get; set; }

        public int ProductId { get; set; }

        public int ProductPartId { get; set; }

        public int Amount { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductPart ProductPart { get; set; }

        public override string ToString()
        {
            return $"{nameof(ProductLineId)}: {ProductLineId}, {nameof(ProductId)}: {ProductId}, {nameof(ProductPartId)}: {ProductPartId}, {nameof(Amount)}: {Amount}, {nameof(Product)}: {Product}, {nameof(ProductPart)}: {ProductPart}";
        }
    }
}
