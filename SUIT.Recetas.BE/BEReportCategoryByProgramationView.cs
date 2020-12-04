using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BEReportCategoryByProgramationView
    {
        public int week { get; set; }
        public string strInitialDate { get; set; }
        public string strFinalDate { get; set; }


        public int categoryId { get; set; }
        public string category { get; set; }
        public decimal subtotal { get; set; }
        public decimal percent { get; set; }

    }
    public class BEReportPodructCategoryByProgramationView
    {
        public int week { get; set; }
        public int weekDay { get; set; }
        public string strInitialDate { get; set; }
        public string strFinalDate { get; set; }
        public string productDate { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public string measure { get; set; }
        public decimal cost { get; set; }
        public decimal quantity { get; set; }
        public int InvoiceItemId { get; set; }
        public decimal Requested { get; set; }


    }
}
