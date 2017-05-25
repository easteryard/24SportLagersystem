using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Model;
using _24SportLagersystem.ViewModel;

namespace _24SportLagersystem.Handler
{
    class ProductHandler
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public ProductHandler(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }

        public void CreateProduct()
        {
            Singleton24Sport.Instance.AddProduct(ViewModel24Sport.ProductId, ViewModel24Sport.ProductName,
                ViewModel24Sport.Height, ViewModel24Sport.Price, ViewModel24Sport.AmountMade,
                ViewModel24Sport.AmountMakeable);
        }

        public static void DeleteProduct()
        {
            Singleton24Sport.Instance.
        }
    }
}
