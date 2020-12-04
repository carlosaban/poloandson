using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class ProgramationResumen
    {
        public int feedingTimeId { get; set; }
        public string feedingTimeName { get; set; }
        public DayOfProgramationResumen saturday { get; set; }
        public DayOfProgramationResumen sunday { get; set; }
        public DayOfProgramationResumen monday { get; set; }
        public DayOfProgramationResumen tuesday { get; set; }
        public DayOfProgramationResumen wednesday { get; set; }
        public DayOfProgramationResumen thursday { get; set; }
        public DayOfProgramationResumen friday { get; set; }

        public ProgramationResumen()
        {
            saturday = new DayOfProgramationResumen();
            sunday = new DayOfProgramationResumen();
            monday = new DayOfProgramationResumen();
            tuesday = new DayOfProgramationResumen();
            wednesday = new DayOfProgramationResumen();
            thursday = new DayOfProgramationResumen();
            friday = new DayOfProgramationResumen();
        }
    }
    public class DayOfProgramationResumen
    {

        public DateTime date { get; set; }
        public string dateFormat { get; set; }
        public List<VE_Programation> programation { get; set; }
        
        public DayOfProgramationResumen()
        {
            programation = new List<VE_Programation>();
        }
    }
}