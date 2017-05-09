using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Product
    {
        public String ProductName { get; set; }
        public String Content { get; set; }
        public double Price { get; set; }
        public int AmountMade { get; set; }

        public Product()
        {
            
        }

        public Product(string productName, string content, double price, int amountMade)
        {
            ProductName = productName;
            Content = content;
            Price = price;
            AmountMade = amountMade;
        }

        public override string ToString()
        {
            return $"{nameof(ProductName)}: {ProductName}, {nameof(Content)}: {Content}, {nameof(Price)}: {Price}, {nameof(AmountMade)}: {AmountMade}";
        }
    }
}
