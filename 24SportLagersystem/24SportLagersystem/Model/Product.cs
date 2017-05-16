using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Product
    {
        //her har vi vores properties
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Height { get; set; }
        public int AmountMade { get; set; }
        public int AmountMakeable { get; set; }

        //dette er vores default konstruktør
        public Product()
        {
            
        }

        //dette er vores konstruktør som initialisere vores properties
        public Product(int productId, string productName, double price, double height, int amountMade, int amountMakeable)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Height = height;
            AmountMade = amountMade;
            AmountMakeable = amountMakeable;
        }

        //dette er vores tostring som gør det muligt at udksrive vores properties
        public override string ToString()
        {
            return $"{nameof(ProductId)}: {ProductId}, {nameof(ProductName)}: {ProductName}, {nameof(Price)}: {Price}, {nameof(Height)}: {Height}, {nameof(AmountMade)}: {AmountMade}, {nameof(AmountMakeable)}: {AmountMakeable}";
        }
    }
}
