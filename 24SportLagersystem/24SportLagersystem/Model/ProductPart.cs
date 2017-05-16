using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class ProductPart
    {
        public int ProductPartId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double PricePerPieceDkk { get; set; }
        public double PricePerPieceEur { get; set; }
        public double PriceTotalDkk { get; set; }
        public double PriceTotalEur { get; set; }

        public ProductPart()
        {

        }

        public ProductPart(int productPartId, string description, int amount, double pricePerPieceDkk, double pricePerPieceEur, double priceTotalDkk, double priceTotalEur)
        {
            ProductPartId = productPartId;
            Description = description;
            Amount = amount;
            PricePerPieceDkk = pricePerPieceDkk;
            PricePerPieceEur = pricePerPieceEur;
            PriceTotalDkk = priceTotalDkk;
            PriceTotalEur = priceTotalEur;
        }

        public override string ToString()
        {
            return $"{nameof(ProductPartId)}: {ProductPartId}, {nameof(Description)}: {Description}, {nameof(Amount)}: {Amount}, {nameof(PricePerPieceDkk)}: {PricePerPieceDkk}, {nameof(PricePerPieceEur)}: {PricePerPieceEur}, {nameof(PriceTotalDkk)}: {PriceTotalDkk}, {nameof(PriceTotalEur)}: {PriceTotalEur}";
        }
    }
}
