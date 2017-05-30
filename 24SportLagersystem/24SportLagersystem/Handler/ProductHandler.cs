using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Model;
using _24SportLagersystem.ViewModel;
using Windows.UI.Popups;

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

        public void EditProduct()
        {
            Singleton24Sport.Instance.EditProduct(ViewModel24Sport.SelectedProduct);
        }

        public void DeleteProduct()
        {
            Singleton24Sport.Instance.DeleteProduct(ViewModel24Sport.SelectedProduct);
        }

        public void SetSelectedProduct(Product products)
        {
            ViewModel24Sport.SelectedProduct = products;
        }

    }
}
