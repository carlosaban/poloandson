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
    public class BL_Headquarters
    {
        public MySQLDatabase _database;
        public string connectionString;

        private List<BE_Headquarters> GetHeadquartersGeneral(BE_Headquarters bE_Headquarters)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Headquarters(_database).GetHeadquartersGeneral(bE_Headquarters);
        }

        public List<BE_Headquarters> GetHeadquarters()
        {
            BE_Headquarters bE_Headquarters = new BE_Headquarters();
            _database = new MySQLDatabase(connectionString);
            return GetHeadquartersGeneral(bE_Headquarters);
        }

        public List<BE_Headquarters> GetHeadquartersById(int headquartersId)
        {
            BE_Headquarters bE_Headquarters = new BE_Headquarters();
            bE_Headquarters.headquartersId = headquartersId;
            _database = new MySQLDatabase(connectionString);
            return GetHeadquartersGeneral(bE_Headquarters);
        }

        public List<BE_Headquarters> GetHeadquartersByTypeId(int headquartersTypeId)
        {
            BE_Headquarters bE_Headquarters = new BE_Headquarters();
            bE_Headquarters.headquartersTypeId = headquartersTypeId;
            _database = new MySQLDatabase(connectionString);
            return GetHeadquartersGeneral(bE_Headquarters);
        }


        public List<BE_Headquarters> GetHeadquartersByName(string name)
        {
            BE_Headquarters bE_Headquarters = new BE_Headquarters();
            bE_Headquarters.name = name;
            _database = new MySQLDatabase(connectionString);
            return GetHeadquartersGeneral(bE_Headquarters);
        }

        public object GetConsolidatedReport(int year, int month, int? sede)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Headquarters(_database).GetConsolidatedReport(year,month,sede);
        }
    }
}
