﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Order()
        {

        }

        public Order(int orderId, int customerId, DateTime orderDate, DateTime deliveryDate)
        {
            OrderId = orderId;
            CustomerId = customerId;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
        }

        public override string ToString()
        {
            return $"{nameof(OrderId)}: {OrderId}, {nameof(CustomerId)}: {CustomerId}, {nameof(OrderDate)}: {OrderDate}, {nameof(DeliveryDate)}: {DeliveryDate}";
        }
    }
}
