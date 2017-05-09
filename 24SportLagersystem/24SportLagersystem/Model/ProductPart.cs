using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class ProductPart
    {
        public int ProductPartNo { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public double PricePrPiece { get; set; }
        public double TotalPrice { get; set; }

        public ProductPart()
        {

        }

        public ProductPart(int productPartNo, int amount, string description, double pricePrPiece, double totalPrice)
        {
            ProductPartNo = productPartNo;
            Amount = amount;
            Description = description;
            PricePrPiece = pricePrPiece;
            TotalPrice = totalPrice;
        }

        public override string ToString()
        {
            return $"{nameof(ProductPartNo)}: {ProductPartNo}, {nameof(Amount)}: {Amount}, {nameof(Description)}: {Description}, {nameof(PricePrPiece)}: {PricePrPiece}, {nameof(TotalPrice)}: {TotalPrice}";
        }
    }
}
