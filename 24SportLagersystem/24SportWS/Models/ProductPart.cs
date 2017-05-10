namespace _24SportWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPart")]
    public partial class ProductPart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductPart()
        {
            ProductLines = new HashSet<ProductLine>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductPart_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int? Amount { get; set; }

        public int PricePerPieceDkk { get; set; }

        public int PricePerPieceEur { get; set; }

        public int? PriceTotalDkk { get; set; }

        public int? PriceTotalEur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLine> ProductLines { get; set; }
    }
}
