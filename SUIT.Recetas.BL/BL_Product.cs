using SUIT.Pago.BE;
using SUIT.Pago.BL;
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
    public class BL_Product
    {
        public MySQLDatabase _database;
        public string connectionString;

        private List<VE_Product> GetProductGeneral(BE_Product bE_Product,string productTypeIdList)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Product(_database).GetProductGeneral(bE_Product,productTypeIdList);
        }

        public List<VE_Product> GetProduct()
        {
           
            BE_Product bE_Product = new BE_Product();
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, "");
        }

        public List<VE_Product> GetProductById(int productId)
        {
            BE_Product bE_Product = new BE_Product();
            bE_Product.productId = productId;
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, "");
        }

        public List<VE_Product> GetProductByTypeId(string productTypeIdList)
        {
            BE_Product bE_Product = new BE_Product();
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, productTypeIdList);
        }

        public List<VE_Product> GetProductByCategoryId(int productCategoryId)
        {
            BE_Product bE_Product = new BE_Product();
            bE_Product.productCategoryId = productCategoryId;
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, "");
        }

        public List<VE_Product> GetProductByName(string name)
        {
            BE_Product bE_Product = new BE_Product();
            bE_Product.name = name;
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, "");
        }

        public List<VE_Product> GetProductByCode(string code)
        {
            BE_Product bE_Product = new BE_Product();
            bE_Product.code = code;
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, "");
        }

        public List<VE_Product> GetProductByDietId(int dietId)
        {
            BE_Product bE_Product = new BE_Product();
            bE_Product.dietId = dietId;
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, "");
        }

        public List<VE_Product> GetProductByHeadquartersId(int headquartersId)
        {
            BE_Product bE_Product = new BE_Product();
            bE_Product.headquartersId = headquartersId;
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, "");
        }

        public List<VE_Product> GetProductByTypeIdAndDietId(int dietId,string productTypeIdList)
        {
            BE_Product bE_Product = new BE_Product();
            bE_Product.dietId = dietId;
            _database = new MySQLDatabase(connectionString);
            return GetProductGeneral(bE_Product, productTypeIdList);
        }

        public List<VE_ProductDetail> GetProductDetailByProductId(int productId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Product(_database).GetProductDetailByProductId(productId);
        }

        private BE_ProductDetail CreateProductDetail(BE_ProductDetail bE_ProductDetail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Product(_database).CreateProductDetail(bE_ProductDetail);
        }

        private int DeleteProductDetailByProductId(int productId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Product(_database).DeleteProductDetailByProductId(productId);
        }

        public BE_Product CreateProduct(BE_Product bE_Product)
        {
            bool bOk = true;
            _database = new MySQLDatabase(connectionString);
            BL_Invoice bL_Invoice = new BL_Invoice();
            bL_Invoice.connectionString = connectionString;

            int filas = GetProductByCode(bE_Product.code).Count;
            if (filas > 0) return null;
            if (filas != 0) bOk = false;

            if (bOk) { 
                        BE_InvoiceItem BE_InvoiceItem = bL_Invoice.AddInvoiceItem(new BE_InvoiceItem()
                        {
                            companyCode = bE_Product.CompanyCode
                                                                        ,
                            igvAffected = true
                                                                        ,
                            IsEnabled = true
                                                                        ,
                            invoiceItemType = "P"
                                                                        ,
                            name = bE_Product.code + "-" + bE_Product.name
                        });
                bE_Product.invoiceItemId =   BE_InvoiceItem.invoiceItemId; 

            }

            var newProduct = new DA_Product(_database).CreateProduct(bE_Product);
            if (bOk && newProduct.detail != null)
            {

                foreach (var detail in newProduct.detail)
                {
                    detail.productId = newProduct.productId;
                    CreateProductDetail(detail);
                }
            }
            return newProduct;
        }

        public BE_Product UpdateProduct(BE_Product bE_Product)
        {
            _database = new MySQLDatabase(connectionString);
            var list = GetProduct();
            foreach (var i in list)
            {
                if (i.code == bE_Product.code && i.productId != bE_Product.productId) return null;
            }
            var updatedProduct = new DA_Product(_database).UpdateProduct(bE_Product);
            
            if (updatedProduct.detail != null)
            {
                DeleteProductDetailByProductId(updatedProduct.productId);
                foreach (var detail in updatedProduct.detail)
                {
                    detail.productId = updatedProduct.productId;
                    CreateProductDetail(detail);
                }
            }
            return updatedProduct;
        }

        public int DuplicateProduct(int productId,string code)
        {
            _database = new MySQLDatabase(connectionString);
            var list = GetProduct();
            foreach (var i in list)
            {
                if (i.code == code) return 0;
            }

            var dupliecatedProductId = new DA_Product(_database).DuplicateProduct(productId, code);

            var lstDetail = GetProductDetailByProductId(productId);

            if (lstDetail.Count() > 0)
            {
                foreach (var detail in lstDetail)
                {
                    detail.productId = dupliecatedProductId;
                    CreateProductDetail(detail);
                }
            }

            return dupliecatedProductId;
        }

        public int DeleteProduct(int productId)
        {
            
            _database = new MySQLDatabase(connectionString);
            
            var deletedProductId = new DA_Product(_database).DeleteProduct(productId);
            DeleteProductDetailByProductId(deletedProductId);
            return deletedProductId;
        }
    }
}
