using SUIT.BE.n;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class RequestResumenByWeekOfMonth
    {
        public RangeOfDate WeekOfMonth { get; set; }
        public List<RequestResumen> listRequest { get; set; }

        public RequestResumenByWeekOfMonth()
        {
            listRequest = new List<RequestResumen>();
        }
    }

    public class RequestResumen
    {
        public int productCategoryId { get; set; }
        public string productCategoryName { get; set; }
        public decimal amount { get; set; }
        public decimal percentage { get; set; }
        public string headquartersName { get; set; }
        public string dietName { get; set; }
        public string dateFormat { get; set; }
    }

    public class RequestByWeekOfMonth
    {
        public RangeOfDate WeekOfMonth { get; set; }
        public List<VE_ProgramationDetail> listRequest { get; set; }

        public RequestByWeekOfMonth()
        {
            listRequest = new List<VE_ProgramationDetail>();
        }
    }
}
