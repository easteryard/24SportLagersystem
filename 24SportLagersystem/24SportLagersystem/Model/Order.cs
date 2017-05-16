using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Order
    {
        //her har vi vores properties
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        //dette er vores default konstruktør
        public Order()
        {

        }

        //dette er vores konstruktør som initialisere vores properties
        public Order(int orderNo, DateTime orderDate, DateTime deliveryDate)
        {
            OrderNo = orderNo;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
        }

        //dette er vores tostring som gør det muligt at udksrive vores properties
        public override string ToString()
        {
            return $"{nameof(OrderNo)}: {OrderNo}, {nameof(OrderDate)}: {OrderDate}, {nameof(DeliveryDate)}: {DeliveryDate}";
        }
    }
}
