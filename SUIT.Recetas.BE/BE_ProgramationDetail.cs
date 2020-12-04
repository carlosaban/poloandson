using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BE_ProgramationDetail
    {
        public int programationId { get; set; }
        public decimal quantity { get; set; }
        public decimal productCost { get; set; }
        public int productId { get; set; }
        public int productKcal { get; set; }

    }
}
