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
    class ProductLineHandler
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public ProductLineHandler(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }

        public void CreateProductLine()
        {
            Singleton24Sport.Instance.AddProductLine(ViewModel24Sport.ProductLineId, ViewModel24Sport.ProductId,
                ViewModel24Sport.ProductPartId, ViewModel24Sport.ProductLineAmount);
        }

        public void EditProductLine()
        {
            Singleton24Sport.Instance.EditProductLine(ViewModel24Sport.SelectedProductLine);
        }

        public void DeleteProductLine()
        {
            Singleton24Sport.Instance.DeleteProductLine(ViewModel24Sport.SelectedProductLine);
        }
    }
}
