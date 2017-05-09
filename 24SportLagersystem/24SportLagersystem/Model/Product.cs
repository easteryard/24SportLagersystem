using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Product
    {
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public string Content { get; set; }
        public double Price { get; set; }
        public double Height { get; set; }
        public int AmountMade { get; set; }
        public int AmountMakeable { get; set; }

        public Product()
        {
            
        }

        public Product(int productNo, string productName, string content, double price, double height, int amountMade, int amountMakeable)
        {
            ProductNo = productNo;
            ProductName = productName;
            Content = content;
            Price = price;
            Height = height;
            AmountMade = amountMade;
            AmountMakeable = amountMakeable;
        }

        public override string ToString()
        {
            return $"{nameof(ProductNo)}: {ProductNo}, {nameof(ProductName)}: {ProductName}, {nameof(Content)}: {Content}, {nameof(Price)}: {Price}, {nameof(Height)}: {Height}, {nameof(AmountMade)}: {AmountMade}, {nameof(AmountMakeable)}: {AmountMakeable}";
        }
    }
}
