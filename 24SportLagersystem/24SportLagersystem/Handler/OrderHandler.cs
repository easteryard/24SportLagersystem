using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Converter;
using _24SportLagersystem.Model;
using _24SportLagersystem.ViewModel;

namespace _24SportLagersystem.Handler
{
    class OrderHandler
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public OrderHandler(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }

        public void CreateOrder()
        {
            Singleton24Sport.Instance.AddOrder(ViewModel24Sport.OrderId, ViewModel24Sport.CustomerId,
                DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel24Sport.OrderDateDate,
                    ViewModel24Sport.OrderDateTime),
                DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel24Sport.DeliveryDateDate,
                    ViewModel24Sport.DeliveryDateTime));
        }

        public void EditOrder()
        {
            Singleton24Sport.Instance.EditOrder(ViewModel24Sport.SelectedOrder);
        }

        public void DeleteOrder()
        {
            Singleton24Sport.Instance.DeleteOrder(ViewModel24Sport.SelectedOrder);
        }
    }
}
