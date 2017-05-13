using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Height { get; set; }
        public int AmountMade { get; set; }
        public int AmountMakeable { get; set; }

        public Product()
        {
            
        }

        public Product(int productId, string productName, double price, double height, int amountMade, int amountMakeable)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Height = height;
            AmountMade = amountMade;
            AmountMakeable = amountMakeable;
        }

        public override string ToString()
        {
            return $"{nameof(ProductId)}: {ProductId}, {nameof(ProductName)}: {ProductName}, {nameof(Price)}: {Price}, {nameof(Height)}: {Height}, {nameof(AmountMade)}: {AmountMade}, {nameof(AmountMakeable)}: {AmountMakeable}";
        }
    }
}
