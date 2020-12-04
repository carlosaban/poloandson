using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class VE_ProgramationDetail:BE_ProgramationDetail
    {
        public string productName { get; set; }
        public DateTime date { get; set; }
        public string dateFormat { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        public int dayOfMonth { get; set; }
        public int weekOfMonth { get; set; }
        public int productCategoryId { get; set; }
        public string productCategoryName { get; set; }
        public string headquartersName { get; set; }
        public string dietName { get; set; }

    }
}
