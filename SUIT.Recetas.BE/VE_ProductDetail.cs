using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class VE_ProductDetail:BE_ProductDetail
    {
        public string productName { get; set; }
        public string productCategoryName { get; set; }  
        public string measuredUnitName { get; set; }

    }
}
