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
    public class BL_ProductCategory
    {
        public MySQLDatabase _database;
        public string connectionString;

        private List<BE_ProductCategory> GetProductCategoryGeneral(BE_ProductCategory bE_ProductCategory)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_ProductCategory(_database).GetProductCategoryGeneral(bE_ProductCategory);
        }

        public List<BE_ProductCategory> GetProductCategory()
        {
            BE_ProductCategory bE_ProductCategory = new BE_ProductCategory();
            _database = new MySQLDatabase(connectionString);
            return GetProductCategoryGeneral(bE_ProductCategory);
        }

        public List<BE_ProductCategory> GetProductCategoryById(int productCategoryId)
        {
            BE_ProductCategory bE_ProductCategory = new BE_ProductCategory();
            bE_ProductCategory.productCategoryId = productCategoryId;
            _database = new MySQLDatabase(connectionString);
            return GetProductCategoryGeneral(bE_ProductCategory);
        }


        public List<BE_ProductCategory> GetProductCategoryByName(string name)
        {
            BE_ProductCategory bE_ProductCategory = new BE_ProductCategory();
            bE_ProductCategory.name = name;
            _database = new MySQLDatabase(connectionString);
            return GetProductCategoryGeneral(bE_ProductCategory);
        }


        public BE_ProductCategory CreateProductCategory(BE_ProductCategory bE_ProductCategory)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_ProductCategory(_database).CreateProductCategory(bE_ProductCategory);

        }

        public BE_ProductCategory UpdateProductCategory(BE_ProductCategory bE_ProductCategory)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_ProductCategory(_database).UpdateProductCategory(bE_ProductCategory);
        }

        public int DeleteProductCategory(int productCategoryId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_ProductCategory(_database).DeleteProductCategory(productCategoryId);

        }
    }
}
