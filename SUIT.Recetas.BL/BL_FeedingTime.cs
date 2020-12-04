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
    public class BL_FeedingTime
    {
        public MySQLDatabase _database;
        public string connectionString;

        private List<BE_FeedingTime> GetFeedingTimeGeneral(BE_FeedingTime bE_FeedingTime)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_FeedingTime(_database).GetFeedingTimeGeneral(bE_FeedingTime);
        }

        public List<BE_FeedingTime> GetFeedingTime()
        {
            BE_FeedingTime bE_FeedingTime = new BE_FeedingTime();
            _database = new MySQLDatabase(connectionString);
            return GetFeedingTimeGeneral(bE_FeedingTime);
        }

        public List<BE_FeedingTime> GetFeedingTimeById(int feedingTimeId)
        {
            BE_FeedingTime bE_FeedingTime = new BE_FeedingTime();
            bE_FeedingTime.feedingTimeId = feedingTimeId;
            _database = new MySQLDatabase(connectionString);
            return GetFeedingTimeGeneral(bE_FeedingTime);
        }

        public List<BE_FeedingTime> GetFeedingTimeByTypeId(int feedingTimeTypeId)
        {
            BE_FeedingTime bE_FeedingTime = new BE_FeedingTime();
            bE_FeedingTime.feedingTimeTypeId = feedingTimeTypeId;
            _database = new MySQLDatabase(connectionString);
            return GetFeedingTimeGeneral(bE_FeedingTime);
        }

        public List<BE_FeedingTime> GetFeedingTimeByDietId(int dietId)
        {
            BE_FeedingTime bE_FeedingTime = new BE_FeedingTime();
            bE_FeedingTime.dietId = dietId;
            _database = new MySQLDatabase(connectionString);
            return GetFeedingTimeGeneral(bE_FeedingTime);
        }

        public List<BE_FeedingTime> GetFeedingTimeByHeadquartersId(int headquartersId)
        {
            BE_FeedingTime bE_FeedingTime = new BE_FeedingTime();
            bE_FeedingTime.headquartersId = headquartersId;
            _database = new MySQLDatabase(connectionString);
            return GetFeedingTimeGeneral(bE_FeedingTime);
        }

        public List<BE_FeedingTime> GetFeedingTimeByDietIdAndHeadquartersId(int dietId, int headquartersId)
        {
            BE_FeedingTime bE_FeedingTime = new BE_FeedingTime();
            bE_FeedingTime.dietId = dietId;
            bE_FeedingTime.headquartersId = headquartersId;
            _database = new MySQLDatabase(connectionString);
            return GetFeedingTimeGeneral(bE_FeedingTime);
        }


        public List<BE_FeedingTime> GetFeedingTimeByName(string name)
        {
            BE_FeedingTime bE_FeedingTime = new BE_FeedingTime();
            bE_FeedingTime.name = name;
            _database = new MySQLDatabase(connectionString);
            return GetFeedingTimeGeneral(bE_FeedingTime);
        }
    }
}
