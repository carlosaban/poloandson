using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BE
{
    public class BE_MeasuredUnit
    {
        public int measuredUnitId { get; set; }
        public string name { get; set; }
        public decimal conversionFactor { get; set; }
        public bool? isBase { get; set; }
        public bool? isEnabled { get; set; }
        public int baseMeasuredUnitId {
            get { return (baseMeasureUnit == null) ? 0 : baseMeasureUnit.measuredUnitId; }
            set { if (baseMeasureUnit == null) this.baseMeasureUnit = new BE_MeasuredUnit() { measuredUnitId = value };
                else this.baseMeasureUnit.baseMeasuredUnitId = value;
   
                 }

        }
        public BE_MeasuredUnit baseMeasureUnit { get; set; }

        public BE_MeasuredUnit()
        {
            isBase = false;


        }

    }
}
