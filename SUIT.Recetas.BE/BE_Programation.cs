using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BE_Programation
    {
        public int programationId { get; set; }
        public DateTime date { get; set; }
        public string dateFormat { get; set; }
        public decimal costTotal { get; set; }
        public int feedingTimeId { get; set; }
        public int kcalTotal { get; set; }
        public bool isEnabled { get; set; }
        public List<BE_ProgramationDetail> detail { get; set; }
    }
}
