using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class VE_Product:BE_Product
    {
        public string productTypeName { get; set; }
        public string productCategoryName { get; set; }
        public string measuredUnitName { get; set; }
        public string dietName { get; set; }
        public string headquartersName { get; set; }
    }
}
