﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportConsole
{
    class ConsoleProductLine
    {
        public int ProductLineId { get; set; }
        public int Amount { get; set; }

        public ConsoleProductLine()
        {

        }

        public ConsoleProductLine(int productLineId, int amount)
        {
            ProductLineId = productLineId;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{nameof(ProductLineId)}: {ProductLineId}, {nameof(Amount)}: {Amount}";
        }
    }
}
