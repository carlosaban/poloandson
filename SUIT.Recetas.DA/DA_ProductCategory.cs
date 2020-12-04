using SUIT.Recetas.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.DA
{
    public class DA_ProductCategory
    {
        public MySQLDatabase _database { get; set; }

        public DA_ProductCategory(MySQLDatabase database)
        {
            _database = database;
        }

        public List<BE_ProductCategory> GetProductCategoryGeneral(BE_ProductCategory bE_ProductCategory)
        {
            BE_ProductCategory _bE_ProductCategory = null;
            List<BE_ProductCategory> _lstProductCategory = new List<BE_ProductCategory>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_productCategoryId", (bE_ProductCategory.productCategoryId == 0) ? DBNull.Value : (object)bE_ProductCategory.productCategoryId);
            parameters.Add("_name", bE_ProductCategory.name);

            var rows = _database.QuerySP("sp_getProductCategoryGeneral", parameters);
            foreach (var row in rows)
            {
                _bE_ProductCategory = new BE_ProductCategory();
                _bE_ProductCategory.productCategoryId = string.IsNullOrEmpty(row["productCategoryId"]) ? 0 : int.Parse(row["productCategoryId"]);
                _bE_ProductCategory.name = row["name"];
                _lstProductCategory.Add(_bE_ProductCategory);
            }

            return _lstProductCategory;
        }

        public BE_ProductCategory CreateProductCategory(BE_ProductCategory bE_ProductCategory)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_name", bE_ProductCategory.name);
            parameters.Add("_isEnabled", bE_ProductCategory.isEnabled);

            var productCategoryId = _database.ExecuteSPGetId("sp_createProductCategory", parameters);

            boResultado = (productCategoryId != null);
            if (boResultado)
            {
                bE_ProductCategory.productCategoryId = int.Parse(productCategoryId.ToString());
                return bE_ProductCategory;

            }
            return null;

        }

        public BE_ProductCategory UpdateProductCategory(BE_ProductCategory bE_ProductCategory)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            int filasAfectadas = 0;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_productCategoryId", bE_ProductCategory.productCategoryId);
            parameters.Add("_name", bE_ProductCategory.name);
            parameters.Add("_isEnabled", bE_ProductCategory.isEnabled);

            filasAfectadas = _database.ExecuteSP("sp_updateProductCategory", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_ProductCategory;

            }
            return null;

        }

        public int DeleteProductCategory(int productCategoryId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_productCategoryId", (productCategoryId == 0) ? DBNull.Value : (object)productCategoryId);

            filasAfectadas = _database.ExecuteSP("sp_deleteProductCategory", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return productCategoryId;
            }
            return 0;
        }


    }
}
