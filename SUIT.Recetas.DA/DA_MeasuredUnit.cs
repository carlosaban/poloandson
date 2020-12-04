using SUIT.Recetas.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.DA
{
    public class DA_MeasuredUnit
    {
        public MySQLDatabase _database { get; set; }

        public DA_MeasuredUnit(MySQLDatabase database)
        {
            _database = database;
        }

        public List<BE_MeasuredUnit> GetMeasuredUnitGeneral(BE_MeasuredUnit bE_MeasuredUnit)
        {
            BE_MeasuredUnit _bE_MeasuredUnit = null;
            List<BE_MeasuredUnit> _lstMeasuredUnit = new List<BE_MeasuredUnit>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_measuredUnitId", (bE_MeasuredUnit.measuredUnitId == 0) ? DBNull.Value : (object)bE_MeasuredUnit.measuredUnitId);
            parameters.Add("_name", string.IsNullOrWhiteSpace(bE_MeasuredUnit.name) ? DBNull.Value : (object)bE_MeasuredUnit.name);
            parameters.Add("_isBase", (bE_MeasuredUnit.isBase == null) ? DBNull.Value : (object)bE_MeasuredUnit.isBase);
            parameters.Add("_isEnabled", (bE_MeasuredUnit.isEnabled == null ) ? DBNull.Value : (object)bE_MeasuredUnit.isEnabled);

            

            var rows = _database.QuerySP("sp_getMeasuredUnitGeneral", parameters);
            foreach (var row in rows)
            {
                _bE_MeasuredUnit = new BE_MeasuredUnit();
                _bE_MeasuredUnit.measuredUnitId = string.IsNullOrEmpty(row["measuredUnitId"]) ? 0 : int.Parse(row["measuredUnitId"]);
                _bE_MeasuredUnit.name = row["name"];
                _bE_MeasuredUnit.conversionFactor = string.IsNullOrEmpty(row["conversionFactor"]) ? 0 : decimal.Parse(row["conversionFactor"]);
                _bE_MeasuredUnit.isBase = string.IsNullOrEmpty(row["isBase"]) ? false : row["isBase"].Equals("1") ? true : false;
                _bE_MeasuredUnit.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                _bE_MeasuredUnit.baseMeasureUnit = new BE_MeasuredUnit() {
                    measuredUnitId = string.IsNullOrEmpty(row["baseMeasuredUnitId"]) ? 0 : int.Parse(row["baseMeasuredUnitId"])
                    ,name = string.IsNullOrEmpty(row["baseName"]) ? string.Empty : row["baseName"]

                    ,conversionFactor = string.IsNullOrEmpty(row["baseConversionFactor"]) ? 0 : decimal.Parse(row["baseConversionFactor"])
                    ,isBase = string.IsNullOrEmpty(row["baseIsBase"]) ? false : row["baseIsBase"].Equals("1") ? true : false
                    ,isEnabled = string.IsNullOrEmpty(row["baseIsEnabled"]) ? false : row["baseIsEnabled"].Equals("1") ? true : false


                };
                //_bE_MeasuredUnit.baseMeasuredUnitId = string.IsNullOrEmpty(row["baseMeasuredUnitId"]) ? 0 : int.Parse(row["baseMeasuredUnitId"]);




                _lstMeasuredUnit.Add(_bE_MeasuredUnit);
            }

            return _lstMeasuredUnit;
        }

        public BE_MeasuredUnit CreateMeasuredUnit(BE_MeasuredUnit bE_MeasuredUnit)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_name", bE_MeasuredUnit.name);
            parameters.Add("_conversionFactor", bE_MeasuredUnit.conversionFactor);
            parameters.Add("_isBase", bE_MeasuredUnit.isBase);
            parameters.Add("_baseMeasuredUnitId", bE_MeasuredUnit.baseMeasuredUnitId);
            

            var measuredUnitId = _database.ExecuteSPGetId("sp_createMeasuredUnit", parameters);

            boResultado = (measuredUnitId != null);
            if (boResultado)
            {
                bE_MeasuredUnit.measuredUnitId = int.Parse(measuredUnitId.ToString());
                return bE_MeasuredUnit;

            }
            return null;

        }

        public BE_MeasuredUnit UpdateMeasuredUnit(BE_MeasuredUnit bE_MeasuredUnit)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            int filasAfectadas = 0;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_measuredUnitId", bE_MeasuredUnit.measuredUnitId);
            parameters.Add("_name", bE_MeasuredUnit.name);
            parameters.Add("_conversionFactor", (bE_MeasuredUnit.conversionFactor == 0) ? DBNull.Value : (object)bE_MeasuredUnit.conversionFactor);
            parameters.Add("_isBase", bE_MeasuredUnit.isBase);

            parameters.Add("_baseMeasuredUnitId", (bE_MeasuredUnit.baseMeasuredUnitId == 0) ? DBNull.Value : (object)bE_MeasuredUnit.baseMeasuredUnitId);

            filasAfectadas = _database.ExecuteSP("sp_updateMeasuredUnit", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_MeasuredUnit;

            }
            return null;

        }

        public int DeleteMeasuredUnit(int measuredUnitId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_measuredUnitId", (measuredUnitId == 0) ? DBNull.Value : (object)measuredUnitId);

            filasAfectadas = _database.ExecuteSP("sp_deleteMeasuredUnit", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return measuredUnitId;
            }
            return 0;
        }
    }
}
