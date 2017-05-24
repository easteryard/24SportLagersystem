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
        public int ProductId { get; set; }
        public int ProductPartId { get; set; }
        public int Amount { get; set; }

        //dette er vores default konstruktør
        public ProductLine()
        {
            
        }

        //dette er vores konstruktør som initialisere vores properties
        public ProductLine(int productLineId, int productId, int productPartId, int amount)
        {
            ProductLineId = productLineId;
            ProductId = productId;
            ProductPartId = productPartId;
            Amount = amount;
        }

        //dette er vores tostring som gør det muligt at udksrive vores properties
        public override string ToString()
        {
            return $"{nameof(ProductLineId)}: {ProductLineId}, {nameof(ProductId)}: {ProductId}, {nameof(ProductPartId)}: {ProductPartId}, {nameof(Amount)}: {Amount}";
        }
    }
}
