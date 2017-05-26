using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Model;
using _24SportLagersystem.ViewModel;

namespace _24SportLagersystem.Handler
{
    class ProductPartHandler
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public ProductPartHandler(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }

        public void CreateProductPart()
        {
            ViewModel24Sport.Singleton24Sport.AddProductPart(ViewModel24Sport.ProductPartId,
                ViewModel24Sport.ProductPartNo, ViewModel24Sport.Description, ViewModel24Sport.Amount,
                ViewModel24Sport.PricePerDkk, ViewModel24Sport.PricePerEur, ViewModel24Sport.PriceTotalDkk,
                ViewModel24Sport.PriceTotalEur);
        }

        public void EditProductPart()
        {
            ViewModel24Sport.Singleton24Sport.EditProductPart(ViewModel24Sport.SelectedProductPart);
        }

        public void DeleteProductPart()
        {
            ViewModel24Sport.Singleton24Sport.DeleteProductPart(ViewModel24Sport.SelectedProductPart);
        }
    }
}
