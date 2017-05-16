using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class ProductPart
    {
        //her har vi vores properties
        public int ProductPartNo { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double PricePerPieceDkk { get; set; }
        public double PricePerPieceEur { get; set; }
        public double PriceTotalDkk { get; set; }
        public double PriceTotalEur { get; set; }

        //dette er vores default konstruktør
        public ProductPart()
        {

        }

        //dette er vores konstruktør som initialisere vores properties
        public ProductPart(int productPartNo, string description, int amount, double pricePerPieceDkk, double pricePerPieceEur, double priceTotalDkk, double priceTotalEur)
        {
            ProductPartNo = productPartNo;
            Description = description;
            Amount = amount;
            PricePerPieceDkk = pricePerPieceDkk;
            PricePerPieceEur = pricePerPieceEur;
            PriceTotalDkk = priceTotalDkk;
            PriceTotalEur = priceTotalEur;
        }

        //dette er vores tostring som gør det muligt at udksrive vores properties
        public override string ToString()
        {
            return $"{nameof(ProductPartNo)}: {ProductPartNo}, {nameof(Description)}: {Description}, {nameof(Amount)}: {Amount}, {nameof(PricePerPieceDkk)}: {PricePerPieceDkk}, {nameof(PricePerPieceEur)}: {PricePerPieceEur}, {nameof(PriceTotalDkk)}: {PriceTotalDkk}, {nameof(PriceTotalEur)}: {PriceTotalEur}";
        }
    }
}
