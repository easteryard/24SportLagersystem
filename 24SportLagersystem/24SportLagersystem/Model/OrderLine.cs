using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class OrderLine
    {
        //her har vi vores properties
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        //dette er vores default konstruktør
        public OrderLine()
        {
            
        }

        //dette er vores konstruktør som initialisere vores properties
        public OrderLine(int orderLineId, int orderId, int productId, int amount)
        {
            OrderLineId = orderLineId;
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
        }

        //dette er vores tostring som gør det muligt at udksrive vores properties
        public override string ToString()
        {
            return $"{nameof(OrderLineId)}: {OrderLineId}, {nameof(OrderId)}: {OrderId}, {nameof(ProductId)}: {ProductId}, {nameof(Amount)}: {Amount}";
        }
    }
}
