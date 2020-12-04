using SUIT.Recetas.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.DA
{
    public class DA_Product
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MySQLDatabase _database { get; set; }

        public DA_Product(MySQLDatabase database)
        {
            _database = database;
        }

        public List<VE_Product> GetProductGeneral(BE_Product bE_Product,string productTypeIdList)
        {
            VE_Product _bE_Product = null;
            List<VE_Product> _lstProduct = new List<VE_Product>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_productId", (bE_Product.productId==0)?DBNull.Value: (object)bE_Product.productId);
            parameters.Add("_code", bE_Product.code);
            parameters.Add("_name", bE_Product.name);
            parameters.Add("_productTypeIdList", productTypeIdList);
            parameters.Add("_productCategoryId", (bE_Product.productCategoryId == 0) ? DBNull.Value : (object)bE_Product.productCategoryId);
            parameters.Add("_dietId", (bE_Product.dietId == 0) ? DBNull.Value : (object)bE_Product.dietId);
            parameters.Add("_headquartersId", (bE_Product.headquartersId == 0) ? DBNull.Value : (object)bE_Product.headquartersId);

            var rows = _database.QuerySP("sp_getProductGeneral", parameters);
            foreach (var row in rows)
            {
                _bE_Product = new VE_Product();
                _bE_Product.productId = string.IsNullOrEmpty(row["productId"]) ? 0 : int.Parse(row["productId"]);
                _bE_Product.code = row["code"];
                _bE_Product.name = row["name"];
                _bE_Product.productTypeId = string.IsNullOrEmpty(row["productTypeId"]) ? 0 : int.Parse(row["productTypeId"]);
                _bE_Product.productTypeName = row["productTypeName"];
                _bE_Product.productCategoryId = string.IsNullOrEmpty(row["productCategoryId"]) ? 0 : int.Parse(row["productCategoryId"]);
                _bE_Product.productCategoryName = row["productCategoryName"];
                _bE_Product.cost = string.IsNullOrEmpty(row["cost"]) ? 0 : decimal.Parse(row["cost"]);
                _bE_Product.salePrice = string.IsNullOrEmpty(row["salePrice"]) ? 0 : decimal.Parse(row["salePrice"]);
                _bE_Product.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                _bE_Product.quantity = string.IsNullOrEmpty(row["quantity"]) ? 0 : decimal.Parse(row["quantity"]);
                _bE_Product.measuredUnitId = string.IsNullOrEmpty(row["measuredUnitId"]) ? 0 : int.Parse(row["measuredUnitId"]);
                _bE_Product.measuredUnitName = row["measuredUnitName"];
                _bE_Product.dietId = string.IsNullOrEmpty(row["dietId"]) ? 0 : int.Parse(row["dietId"]);
                _bE_Product.dietName = row["dietName"];
                _bE_Product.headquartersId = string.IsNullOrEmpty(row["headquartersId"]) ? 0 : int.Parse(row["headquartersId"]);
                _bE_Product.headquartersName = row["headquartersName"];
                _bE_Product.kcalTotal = string.IsNullOrEmpty(row["kcalTotal"]) ? 0 : int.Parse(row["kcalTotal"]);

                _bE_Product.waste = string.IsNullOrEmpty(row["waste"]) ? 0 : decimal.Parse(row["waste"]);
                _bE_Product.costbyRecipeMeasureUnit = string.IsNullOrEmpty(row["costbyRecipeMeasureUnit"]) ? 0 : decimal.Parse(row["costbyRecipeMeasureUnit"]);
                _bE_Product.RecipeMeasureUnitId = string.IsNullOrEmpty(row["RecipeMeasureUnitId"]) ? 0 : int.Parse(row["RecipeMeasureUnitId"]);

                _lstProduct.Add(_bE_Product);
            }

            return _lstProduct;
        }

        public List<VE_ProductDetail> GetProductDetailByProductId(int productId)
        {
            VE_ProductDetail _bE_ProductDetail = null;
            List<VE_ProductDetail> _lstProductDetail = new List<VE_ProductDetail>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_productId", (productId == 0) ? DBNull.Value : (object)productId);

            var rows = _database.QuerySP("sp_getProductDetailByProductId", parameters);
            foreach (var row in rows)
            {
                _bE_ProductDetail = new VE_ProductDetail();
                _bE_ProductDetail.productDetailId = string.IsNullOrEmpty(row["productDetailId"]) ? 0 : int.Parse(row["productDetailId"]);
                _bE_ProductDetail.quantity = string.IsNullOrEmpty(row["quantity"]) ? 0 : decimal.Parse(row["quantity"]);
                _bE_ProductDetail.kcal = string.IsNullOrEmpty(row["kcal"]) ? 0 : int.Parse(row["kcal"]);
                _bE_ProductDetail.cost = string.IsNullOrEmpty(row["cost"]) ? 0 : decimal.Parse(row["cost"]);
                _bE_ProductDetail.productId = string.IsNullOrEmpty(row["productId"]) ? 0 : int.Parse(row["productId"]);
                _bE_ProductDetail.productItemId = string.IsNullOrEmpty(row["productItemId"]) ? 0 : int.Parse(row["productItemId"]);
                _bE_ProductDetail.productName = row["productName"];
                _bE_ProductDetail.measuredUnitId = string.IsNullOrEmpty(row["measuredUnitId"]) ? 0 : int.Parse(row["measuredUnitId"]);
                _bE_ProductDetail.measuredUnitName = row["measuredUnitName"];
                _bE_ProductDetail.productCategoryName = row["productCategoryName"];


                _lstProductDetail.Add(_bE_ProductDetail);
            }

            return _lstProductDetail;
        }

        public BE_Product CreateProduct(BE_Product bE_Product)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            try
            {
                logger.Debug("In CreateProduct(bE_Product) ");
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("_code", bE_Product.code);
                parameters.Add("_name", bE_Product.name);
                parameters.Add("_productTypeId", bE_Product.productTypeId);
                parameters.Add("_productCategoryId", (bE_Product.productCategoryId == 0) ? DBNull.Value : (object)bE_Product.productCategoryId);
                parameters.Add("_cost", bE_Product.cost);
                parameters.Add("_salePrice", bE_Product.salePrice);
                parameters.Add("_quantity", (bE_Product.quantity == 0) ? DBNull.Value : (object)bE_Product.quantity);
                parameters.Add("_measuredUnitId", (bE_Product.measuredUnitId == 0) ? DBNull.Value : (object)bE_Product.measuredUnitId);
                parameters.Add("_dietId", (bE_Product.dietId == 0) ? DBNull.Value : (object)bE_Product.dietId);
                parameters.Add("_headquartersId", (bE_Product.headquartersId == 0) ? DBNull.Value : (object)bE_Product.headquartersId);
                parameters.Add("_kcalTotal", (bE_Product.kcalTotal == 0) ? DBNull.Value : (object)bE_Product.kcalTotal);

                parameters.Add("_waste", bE_Product.waste);
                parameters.Add("_costbyRecipeMeasureUnit", bE_Product.costbyRecipeMeasureUnit);
                parameters.Add("_RecipeMeasureUnitId", (bE_Product.RecipeMeasureUnitId == 0) ? DBNull.Value : (object)bE_Product.RecipeMeasureUnitId);

                var productId = _database.ExecuteSPGetId("sp_createProduct", parameters);

                boResultado = (productId != null);
                if (boResultado)
                {
                    bE_Product.productId = int.Parse(productId.ToString());
                    return bE_Product;

                }
                return null;


            }
            catch (Exception ex)
            {
                logger.Fatal(ex,"CreateProduct(bE_Product) Exception: " + ex.Message);
                throw ex;
            }
            

        }

        public BE_ProductDetail CreateProductDetail(BE_ProductDetail bE_ProductDetail)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_quantity", bE_ProductDetail.quantity);
            parameters.Add("_kcal", bE_ProductDetail.kcal);
            parameters.Add("_cost", bE_ProductDetail.cost);
            parameters.Add("_productId", (bE_ProductDetail.productId == 0) ? DBNull.Value : (object)bE_ProductDetail.productId);
            parameters.Add("_productItemId", (bE_ProductDetail.productItemId == 0) ? DBNull.Value : (object)bE_ProductDetail.productItemId);
            parameters.Add("_measuredUnitId", (bE_ProductDetail.measuredUnitId == 0) ? DBNull.Value : (object)bE_ProductDetail.measuredUnitId);

            var productDetailId = _database.ExecuteSPGetId("sp_createProductDetail", parameters);

            boResultado = (productDetailId != null);
            if (boResultado)
            {
                bE_ProductDetail.productDetailId = int.Parse(productDetailId.ToString());
                return bE_ProductDetail;

            }
            return null;

        }

        public BE_Product UpdateProduct(BE_Product bE_Product)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_productId", (bE_Product.productId == 0) ? DBNull.Value : (object)bE_Product.productId);
            parameters.Add("_code", bE_Product.code);
            parameters.Add("_name", bE_Product.name);
            parameters.Add("_productTypeId", bE_Product.productTypeId);
            parameters.Add("_productCategoryId", (bE_Product.productCategoryId == 0) ? DBNull.Value : (object)bE_Product.productCategoryId);
            parameters.Add("_cost", bE_Product.cost);
            parameters.Add("_salePrice", bE_Product.salePrice);
            parameters.Add("_quantity", (bE_Product.quantity == 0) ? DBNull.Value : (object)bE_Product.quantity);
            parameters.Add("_measuredUnitId", (bE_Product.measuredUnitId == 0) ? DBNull.Value : (object)bE_Product.measuredUnitId);
            parameters.Add("_dietId", (bE_Product.dietId == 0) ? DBNull.Value : (object)bE_Product.dietId);
            parameters.Add("_headquartersId", (bE_Product.headquartersId == 0) ? DBNull.Value : (object)bE_Product.headquartersId);
            parameters.Add("_kcalTotal", (bE_Product.kcalTotal == 0) ? DBNull.Value : (object)bE_Product.kcalTotal);

            parameters.Add("_waste", bE_Product.waste);
            parameters.Add("_costbyRecipeMeasureUnit", bE_Product.costbyRecipeMeasureUnit);
            parameters.Add("_RecipeMeasureUnitId", (bE_Product.RecipeMeasureUnitId == 0) ? DBNull.Value : (object)bE_Product.RecipeMeasureUnitId);


            filasAfectadas = _database.ExecuteSP("sp_updateProduct", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_Product;

            }
            return null;

        }

        public int DeleteProduct(int productId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_productId", (productId == 0) ? DBNull.Value : (object)productId);

            filasAfectadas = _database.ExecuteSP("sp_deleteProduct", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return productId;
            }
            return 0;
        }

        public int DeleteProductDetailByProductId(int productId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_productId", (productId == 0) ? DBNull.Value : (object)productId);

            filasAfectadas = _database.ExecuteSP("sp_deleteProductDetailByProductId", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return filasAfectadas;
            }
            return 0;
        }

        public int DuplicateProduct(int productId,string code)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_code", code);
            parameters.Add("_productId", productId);
            var duplicatedProductId = _database.ExecuteSPGetId("sp_duplicateProduct", parameters);

            boResultado = (duplicatedProductId != null);
            if (boResultado)
            {
                return int.Parse(duplicatedProductId.ToString());
            }
            return 0;

        }
    }
}
