using SUIT.Recetas.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.DA
{
    public class DA_FeedingTime
    {

        public MySQLDatabase _database { get; set; }

        public DA_FeedingTime(MySQLDatabase database)
        {
            _database = database;
        }

        public List<BE_FeedingTime> GetFeedingTimeGeneral(BE_FeedingTime bE_FeedingTime)
        {
            BE_FeedingTime _bE_FeedingTime = null;
            List<BE_FeedingTime> _lstFeedingTime = new List<BE_FeedingTime>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_feedingTimeId", (bE_FeedingTime.feedingTimeId == 0) ? DBNull.Value : (object)bE_FeedingTime.feedingTimeId);
            parameters.Add("_feedingTimeTypeId", (bE_FeedingTime.feedingTimeTypeId == 0) ? DBNull.Value : (object)bE_FeedingTime.feedingTimeTypeId);
            parameters.Add("_dietId", (bE_FeedingTime.dietId == 0) ? DBNull.Value : (object)bE_FeedingTime.dietId);
            parameters.Add("_headquartersId", (bE_FeedingTime.headquartersId == 0) ? DBNull.Value : (object)bE_FeedingTime.headquartersId);
            parameters.Add("_name", bE_FeedingTime.name);

            var rows = _database.QuerySP("sp_getFeedingTimeGeneral", parameters);
            foreach (var row in rows)
            {
                _bE_FeedingTime = new BE_FeedingTime();
                _bE_FeedingTime.feedingTimeId = string.IsNullOrEmpty(row["feedingTimeId"]) ? 0 : int.Parse(row["feedingTimeId"]);
                _bE_FeedingTime.name = row["name"];
                _bE_FeedingTime.kcalTotal = string.IsNullOrEmpty(row["kcalTotal"]) ? 0 : int.Parse(row["kcalTotal"]);
                _bE_FeedingTime.kcalProteins = string.IsNullOrEmpty(row["kcalProteins"]) ? 0 : int.Parse(row["kcalProteins"]);
                _bE_FeedingTime.kcalGrease = string.IsNullOrEmpty(row["kcalGrease"]) ? 0 : int.Parse(row["kcalGrease"]);
                _bE_FeedingTime.kcalCHD = string.IsNullOrEmpty(row["kcalCHD"]) ? 0 : int.Parse(row["kcalCHD"]);
                _bE_FeedingTime.feedingTimeTypeId = string.IsNullOrEmpty(row["feedingTimeTypeId"]) ? 0 : int.Parse(row["feedingTimeTypeId"]);
                _bE_FeedingTime.dietId = string.IsNullOrEmpty(row["dietId"]) ? 0 : int.Parse(row["dietId"]);
                _bE_FeedingTime.headquartersId = string.IsNullOrEmpty(row["headquartersId"]) ? 0 : int.Parse(row["headquartersId"]);
                _bE_FeedingTime.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                _lstFeedingTime.Add(_bE_FeedingTime);
            }

            return _lstFeedingTime;
        }
    }
}
