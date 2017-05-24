using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Converter;
using _24SportLagersystem.ViewModel;

namespace _24SportLagersystem.Handler
{
    class Handler24Sport
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public Handler24Sport(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }

        public void CreateProduct()
        {
            ViewModel24Sport.Singleton24Sport.AddProduct(ViewModel24Sport.ProductId, ViewModel24Sport.ProductName,
                ViewModel24Sport.Price, ViewModel24Sport.Height, ViewModel24Sport.AmountMade,
                ViewModel24Sport.AmountMakeable);
        }

        public void CreateProductPart()
        {
            ViewModel24Sport.Singleton24Sport.AddProductPart(ViewModel24Sport.ProductPartId, ViewModel24Sport.ProductPartNo, ViewModel24Sport.Description, ViewModel24Sport.Amount, ViewModel24Sport.PricePerDkk, ViewModel24Sport.PricePerEur, ViewModel24Sport.PriceTotalDkk, ViewModel24Sport.PriceTotalEur);
        }

        public void CreateCustomer()
        {
            ViewModel24Sport.Singleton24Sport.AddCustomer(ViewModel24Sport.CustomerId, ViewModel24Sport.Name, ViewModel24Sport.PhoneNo, ViewModel24Sport.Address, ViewModel24Sport.Email);
        }

        public void CreateOrder()
        {
            ViewModel24Sport.Singleton24Sport.AddOrder(ViewModel24Sport.OrderId, ViewModel24Sport.CustomerId, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel24Sport.OrderDate, ViewModel24Sport.TimeSpan), DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel24Sport.DeliveryDate, ViewModel24Sport.TimeSpan));
        }

    }
}
