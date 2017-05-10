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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductLine_Id { get; set; }

        public int Product_Id { get; set; }

        public int ProductPart_Id { get; set; }

        public int Amount { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductPart ProductPart { get; set; }

        public override string ToString()
        {
            return $"{nameof(ProductLine_Id)}: {ProductLine_Id}, {nameof(Product_Id)}: {Product_Id}, {nameof(ProductPart_Id)}: {ProductPart_Id}, {nameof(Amount)}: {Amount}, {nameof(Product)}: {Product}, {nameof(ProductPart)}: {ProductPart}";
        }
    }
}
