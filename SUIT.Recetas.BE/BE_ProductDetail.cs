using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BE_ProductDetail
    {
        public int productDetailId { get; set; }
        public decimal quantity { get; set; }
        public decimal cost { get; set; }
        public int productId { get; set; }
        public int productItemId { get; set; }
        public int measuredUnitId { get; set; }
        public int kcal { get; set; }
    }
}
