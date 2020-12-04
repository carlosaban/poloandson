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
    public class BL_Diet
    {
        public MySQLDatabase _database;
        public string connectionString;

        private List<BE_Diet> GetDietGeneral(BE_Diet bE_Diet)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Diet(_database).GetDietGeneral(bE_Diet);
        }

        public List<BE_Diet> GetDiet()
        {
            BE_Diet bE_Diet = new BE_Diet();
            _database = new MySQLDatabase(connectionString);
            return GetDietGeneral(bE_Diet);
        }

        public List<BE_Diet> GetDietById(int dietId)
        {
            BE_Diet bE_Diet = new BE_Diet();
            bE_Diet.dietId = dietId;
            _database = new MySQLDatabase(connectionString);
            return GetDietGeneral(bE_Diet);
        }

        public List<BE_Diet> GetDietByName(string name)
        {
            BE_Diet bE_Diet = new BE_Diet();
            bE_Diet.name = name;
            _database = new MySQLDatabase(connectionString);
            return GetDietGeneral(bE_Diet);
        }

        public List<VE_Diet> GetDietByHeadquartersId(int headquartersId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Diet(_database).GetDietByHeadquartersId(headquartersId);
        }
    }
}
