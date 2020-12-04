using SUIT.Recetas.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.DA
{
    public class DA_Headquarters
    {
        public MySQLDatabase _database { get; set; }

        public DA_Headquarters(MySQLDatabase database)
        {
            _database = database;
        }

        public List<BE_Headquarters> GetHeadquartersGeneral(BE_Headquarters bE_Headquarters)
        {
            BE_Headquarters _bE_Headquarters = null;
            List<BE_Headquarters> _lstHeadquarters = new List<BE_Headquarters>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_headquartersId", (bE_Headquarters.headquartersId == 0) ? DBNull.Value : (object)bE_Headquarters.headquartersId);
            parameters.Add("_headquartersTypeId", (bE_Headquarters.headquartersTypeId == 0) ? DBNull.Value : (object)bE_Headquarters.headquartersTypeId);
            parameters.Add("_name", bE_Headquarters.name);

            var rows = _database.QuerySP("sp_getHeadquartersGeneral", parameters);
            foreach (var row in rows)
            {
                _bE_Headquarters = new BE_Headquarters();
                _bE_Headquarters.headquartersId = string.IsNullOrEmpty(row["headquartersId"]) ? 0 : int.Parse(row["headquartersId"]);
                _bE_Headquarters.headquartersTypeId = string.IsNullOrEmpty(row["headquartersTypeId"]) ? 0 : int.Parse(row["headquartersTypeId"]);
                _bE_Headquarters.name = row["name"];
                _bE_Headquarters.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                _lstHeadquarters.Add(_bE_Headquarters);
            }

            return _lstHeadquarters;
        }

        public object GetConsolidatedReport(int year, int month, int? sede)
        {

            BEReportSummaryView _bE_Headquarters = null;
            List<BEReportSummaryView> _lstHeadquarters = new List<BEReportSummaryView>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_year", (year == 0) ? DBNull.Value : (object)year);
            parameters.Add("_month", (month == 0) ? DBNull.Value : (object)month);
            parameters.Add("_sede", (sede == null || sede == 0) ? DBNull.Value : (object)sede);

            var rows = _database.QuerySP("receta_sps_getConsolidatedReport", parameters);
            foreach (var row in rows)
            {
                _bE_Headquarters  = new BEReportSummaryView();
                _bE_Headquarters.headquartersName = row["headquartersName"];
                _bE_Headquarters.headquartersId = row["headquartersId"];
                _bE_Headquarters.Cost = decimal.Parse ( row["Cost"].ToString() );

                _bE_Headquarters.GrossAmount = decimal.Parse(row["GrossAmount"].ToString());

                _bE_Headquarters.NetAmount = decimal.Parse(row["NetAmount"].ToString());
                _lstHeadquarters.Add(_bE_Headquarters);
            }

            return _lstHeadquarters;

        }
    }
}
