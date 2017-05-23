using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerId { get; set; }

        public Order()
        {

        }

        public Order(int orderId, DateTime orderDate, DateTime deliveryDate, int customerId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            CustomerId = customerId;
        }

        public override string ToString()
        {
            return $"{nameof(OrderId)}: {OrderId}, {nameof(OrderDate)}: {OrderDate}, {nameof(DeliveryDate)}: {DeliveryDate}, {nameof(CustomerId)}: {CustomerId}";
        }
    }
}
