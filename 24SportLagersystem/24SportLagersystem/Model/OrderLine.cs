using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class OrderLine
    {
        public int OrderLineId { get; set; }
        public int Amount { get; set; }

        public OrderLine()
        {
            
        }

        public OrderLine(int orderLineId, int amount)
        {
            OrderLineId = orderLineId;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{nameof(OrderLineId)}: {OrderLineId}, {nameof(Amount)}: {Amount}";
        }
    }
}
