using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Order
    {
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Order()
        {

        }

        public Order(int orderNo, DateTime orderDate, DateTime deliveryDate)
        {
            OrderNo = orderNo;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
        }

        public override string ToString()
        {
            return $"{nameof(OrderNo)}: {OrderNo}, {nameof(OrderDate)}: {OrderDate}, {nameof(DeliveryDate)}: {DeliveryDate}";
        }
    }
}
