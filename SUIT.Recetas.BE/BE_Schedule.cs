using SUIT.Pago.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BE_Schedule
    {
        public VE_Invoice Invoice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Delivery { get; set; }
        public int PaymentMethod { get; set; }

    }
}
