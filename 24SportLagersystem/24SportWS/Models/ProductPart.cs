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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductPartId { get; set; }

        public int ProductPartNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int? Amount { get; set; }

        public double PricePerPieceDkk { get; set; }

        public double PricePerPieceEur { get; set; }

        public double? PriceTotalDkk { get; set; }

        public double? PriceTotalEur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLine> ProductLines { get; set; }

        public override string ToString()
        {
            return $"{nameof(ProductPartId)}: {ProductPartId}, {nameof(ProductPartNo)}: {ProductPartNo}, {nameof(Description)}: {Description}, {nameof(Amount)}: {Amount}, {nameof(PricePerPieceDkk)}: {PricePerPieceDkk}, {nameof(PricePerPieceEur)}: {PricePerPieceEur}, {nameof(PriceTotalDkk)}: {PriceTotalDkk}, {nameof(PriceTotalEur)}: {PriceTotalEur}";
        }
    }
}
