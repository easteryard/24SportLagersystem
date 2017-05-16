using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportConsole
{
    class ConsoleOrderLine
    {
        public int OrderLineId { get; set; }
        public int Amount { get; set; }

        public ConsoleOrderLine()
        {

        }

        public ConsoleOrderLine(int orderLineId, int amount)
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
