using SUIT.BE.n;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class ProgramationResumenByWeekOfMonth
    {
        public RangeOfDate WeekOfMonth { get; set; }
        public List<ProgramationResumen> listProgramation { get; set; }

        public ProgramationResumenByWeekOfMonth()
        {
            listProgramation = new List<ProgramationResumen>();
        }
    }

    public class ProgramationByWeekOfMonth
    {
        public RangeOfDate WeekOfMonth { get; set; }
        public List<VE_Programation> listProgramation { get; set; }

        public ProgramationByWeekOfMonth()
        {
            listProgramation = new List<VE_Programation>();
        }
    }
}
