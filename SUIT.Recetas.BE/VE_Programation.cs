using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class VE_Programation:BE_Programation
    {
        public string feedingTimeName { get; set; }
        public string headquartersName { get; set; }
        public string dietName { get; set; }
        public string productName { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        public int dayOfMonth { get; set; }
        public decimal quantity { get; set; }
        public int weekOfMonth { get; set; }
    }
}
