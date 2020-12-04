using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BE_FeedingTime
    {
        public int feedingTimeId { get; set; }
        public string name { get; set; }
        public int kcalTotal { get; set; }
        public int kcalProteins { get; set; }
        public int kcalGrease { get; set; }
        public int kcalCHD { get; set; }
        public int feedingTimeTypeId { get; set; }
        public int dietId { get; set; }
        public int headquartersId { get; set; }
        public bool isEnabled { get; set; }
    }
}
