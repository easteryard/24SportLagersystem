using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Order
    {
        public int OrderNr { get; set; }
        public DateTime DateTime { get; set; }
        public String Content { get; set; }

        public Order()
        {

        }

        public Order(int orderNr, DateTime dateTime, string content)
        {
            OrderNr = orderNr;
            DateTime = dateTime;
            Content = content;
        }

        public override string ToString()
        {
            return $"{nameof(OrderNr)}: {OrderNr}, {nameof(DateTime)}: {DateTime}, {nameof(Content)}: {Content}";
        }
    }
}
