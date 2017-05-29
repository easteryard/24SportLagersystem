using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Model;
using _24SportLagersystem.ViewModel;

namespace _24SportLagersystem.Handler
{
    class OrderLineHandler
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public OrderLineHandler(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }

        public void CreateOrderLine()
        {
            Singleton24Sport.Instance.AddOrderLine(ViewModel24Sport.OrderLineId, ViewModel24Sport.OrderId,
                ViewModel24Sport.ProductId, ViewModel24Sport.Amount);
        }

        public void EditOrderLine()
        {
            Singleton24Sport.Instance.EditOrderLine(ViewModel24Sport.SelectedOrderLine);
        }

        public void DeleteOrderLine()
        {
            Singleton24Sport.Instance.DeleteOrderLine(ViewModel24Sport.SelectedOrderLine);
        }
    }
}
