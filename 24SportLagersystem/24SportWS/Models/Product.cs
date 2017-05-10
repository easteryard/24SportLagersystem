namespace _24SportWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
            ProductLines = new HashSet<ProductLine>();
        }

        [Key]
        public int Product_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        public double Price { get; set; }

        public double Height { get; set; }

        public int? AmountMade { get; set; }

        public int? AmountMakeable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLine> ProductLines { get; set; }

        public override string ToString()
        {
            return $"{nameof(Product_Id)}: {Product_Id}, {nameof(Product_Name)}: {Product_Name}, {nameof(Price)}: {Price}, {nameof(Height)}: {Height}, {nameof(AmountMade)}: {AmountMade}, {nameof(AmountMakeable)}: {AmountMakeable}";
        }
    }
}
