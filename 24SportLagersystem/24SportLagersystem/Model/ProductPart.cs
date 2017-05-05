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
        public int Amount { get; set; }
        public string Description { get; set; }
        public double PricePrPieceEuro { get; set; }
        public double PricePrPieceDKK { get; set; }
        public double PriceTotalEuro { get; set; }
        public double PriceTotalDKK { get; set; }

        public ProductPart(int productPartId, int amount, string description, double pricePrPieceEuro, double pricePrPieceDkk, double priceTotalEuro, double priceTotalDkk)
        {
            ProductPartId = productPartId;
            Amount = amount;
            Description = description;
            PricePrPieceEuro = pricePrPieceEuro;
            PricePrPieceDKK = pricePrPieceDkk;
            PriceTotalEuro = priceTotalEuro;
            PriceTotalDKK = priceTotalDkk;
        }

        public ProductPart()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(ProductPartId)}: {ProductPartId}, {nameof(Amount)}: {Amount}, {nameof(Description)}: {Description}, {nameof(PricePrPieceEuro)}: {PricePrPieceEuro}, {nameof(PricePrPieceDKK)}: {PricePrPieceDKK}, {nameof(PriceTotalEuro)}: {PriceTotalEuro}, {nameof(PriceTotalDKK)}: {PriceTotalDKK}";
        }
    }
}
