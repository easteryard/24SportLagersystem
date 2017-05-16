using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class ProductLine
    {
        //her har vi vores properties
        public int ProductLineId { get; set; }
        public int Amount { get; set; }

        //dette er vores default konstruktør
        public ProductLine()
        {
            
        }

        //dette er vores konstruktør som initialisere vores properties
        public ProductLine(int productLineId, int amount)
        {
            ProductLineId = productLineId;
            Amount = amount;
        }

        //dette er vores tostring som gør det muligt at udksrive vores properties
        public override string ToString()
        {
            return $"{nameof(ProductLineId)}: {ProductLineId}, {nameof(Amount)}: {Amount}";
        }
    }
}
