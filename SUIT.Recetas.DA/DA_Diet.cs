using SUIT.Recetas.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.DA
{
    public class DA_Diet
    {

        public MySQLDatabase _database { get; set; }

        public DA_Diet(MySQLDatabase database)
        {
            _database = database;
        }

        public List<BE_Diet> GetDietGeneral(BE_Diet bE_Diet)
        {
            BE_Diet _bE_Diet = null;
            List<BE_Diet> _lstDiet = new List<BE_Diet>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_dietId", (bE_Diet.dietId == 0) ? DBNull.Value : (object)bE_Diet.dietId);
            parameters.Add("_name", bE_Diet.name);

            var rows = _database.QuerySP("sp_getDietGeneral", parameters);
            foreach (var row in rows)
            {
                _bE_Diet = new BE_Diet();
                _bE_Diet.dietId = string.IsNullOrEmpty(row["dietId"]) ? 0 : int.Parse(row["dietId"]);
                _bE_Diet.name = row["name"];
                _bE_Diet.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                _lstDiet.Add(_bE_Diet);
            }

            return _lstDiet;
        }

        public List<VE_Diet> GetDietByHeadquartersId(int headquartersId)
        {
            VE_Diet _bE_Diet = null;
            List<VE_Diet> _lstDiet = new List<VE_Diet>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_headquartersId", headquartersId);

            var rows = _database.QuerySP("sp_getDietByHeadquartersId", parameters);
            foreach (var row in rows)
            {
                _bE_Diet = new VE_Diet();
                _bE_Diet.dietId = string.IsNullOrEmpty(row["dietId"]) ? 0 : int.Parse(row["dietId"]);
                _bE_Diet.headquartersId = string.IsNullOrEmpty(row["headquartersId"]) ? 0 : int.Parse(row["headquartersId"]);
                _bE_Diet.VCT = string.IsNullOrEmpty(row["VCT"]) ? 0 : int.Parse(row["VCT"]);
                _bE_Diet.name = row["name"];
                _bE_Diet.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                _lstDiet.Add(_bE_Diet);
            }

            return _lstDiet;
        }

    }
}
