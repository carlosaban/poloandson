using SUIT.Recetas.BE;
using SUIT.Recetas.DA;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BL
{
    public class BL_MeasuredUnit
    {
        public MySQLDatabase _database;
        public string connectionString;

        public List<BE_MeasuredUnit> GetMeasuredUnitGeneral(BE_MeasuredUnit bE_MeasuredUnit)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_MeasuredUnit(_database).GetMeasuredUnitGeneral(bE_MeasuredUnit);
        }

        public List<BE_MeasuredUnit> GetMeasuredUnit()
        {
            BE_MeasuredUnit bE_MeasuredUnit = new BE_MeasuredUnit() { isEnabled = true};
            _database = new MySQLDatabase(connectionString);
            return GetMeasuredUnitGeneral(bE_MeasuredUnit);
        }

        public List<BE_MeasuredUnit> GetMeasuredUnitById(int measuredUnitId)
        {
            BE_MeasuredUnit bE_MeasuredUnit = new BE_MeasuredUnit();
            bE_MeasuredUnit.measuredUnitId = measuredUnitId;
            _database = new MySQLDatabase(connectionString);
            return GetMeasuredUnitGeneral(bE_MeasuredUnit);
        }


        public List<BE_MeasuredUnit> GetMeasuredUnitByName(string name)
        {
            BE_MeasuredUnit bE_MeasuredUnit = new BE_MeasuredUnit();
            bE_MeasuredUnit.name = name;
            _database = new MySQLDatabase(connectionString);
            return GetMeasuredUnitGeneral(bE_MeasuredUnit);
        }


        public BE_MeasuredUnit CreateMeasuredUnit(BE_MeasuredUnit bE_MeasuredUnit)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_MeasuredUnit(_database).CreateMeasuredUnit(bE_MeasuredUnit);
            
        }

        public BE_MeasuredUnit UpdateMeasuredUnit(BE_MeasuredUnit bE_MeasuredUnit)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_MeasuredUnit(_database).UpdateMeasuredUnit(bE_MeasuredUnit);
        }

        public int DeleteMeasuredUnit(int measuredUnitId)
        {
            _database = new MySQLDatabase(connectionString);                        
            return new DA_MeasuredUnit(_database).DeleteMeasuredUnit(measuredUnitId);

        }
    }
}
