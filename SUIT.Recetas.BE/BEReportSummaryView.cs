using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BEReportSummaryView
    {
        public string headquartersName { get; set; }
       public string headquartersId { get; set; }
        public decimal Cost { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
    }
}
