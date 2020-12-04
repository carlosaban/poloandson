using Newtonsoft.Json;
using SUIT.BE;
using SUIT.Recetas.BE;
using SUIT.Recetas.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SUIT.Controllers
{
    public class ProductController : ApiController
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [Route("api/Product/GetProduct")]
        [HttpGet]
        public BE_Json GetProduct()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProduct());

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }
        
        [Route("api/Product/GetProductById/{productId}")]
        [HttpGet]
        public BE_Json GetProductById(int productId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductById(productId));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/GetProductByTypeId/{productTypeIdList}")]
        [HttpGet]
        public BE_Json GetProductByTypeId(string productTypeIdList)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductByTypeId(productTypeIdList));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/GetProductByCategoryId/{productCategoryId}")]
        [HttpGet]
        public BE_Json GetProductByCategoryId(int productCategoryId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductByCategoryId(productCategoryId));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/GetProductByName/{name}")]
        [HttpGet]
        public BE_Json GetProductByName(string name)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductByName(name));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/GetProductByCode/{code}")]
        [HttpGet]
        public BE_Json GetProductByCode(string code)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductByCode(code));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/GetProductByDietId/{dietId}")]
        [HttpGet]
        public BE_Json GetProductByDietId(int dietId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductByDietId(dietId));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/GetProductByHeadquartersId/{headquartersId}")]
        [HttpGet]
        public BE_Json GetProductByHeadquartersId(int headquartersId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductByHeadquartersId(headquartersId));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/GetProductByTypeIdAndDietId/{productTypeIdList}/{dietId}")]
        [HttpGet]
        public BE_Json GetProductByTypeIdAndDietId(string productTypeIdList, int dietId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductByTypeIdAndDietId(dietId,productTypeIdList));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/GetProductDetailByProductId/{productId}")]
        [HttpGet]
        public BE_Json GetProductDetailByProductId(int productId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.GetProductDetailByProductId(productId));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/DuplicateProduct/{productId}/{code}")]
        [HttpGet]
        public BE_Json DuplicateProduct(int productId,string code)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.DuplicateProduct(productId, code));

                objJson = new BE_Json();
                objJson.data = (objListaAux == "0") ? "No de pudo duplicar el producto: El código ya existe" : objListaAux;
                objJson.status = (objListaAux == "0") ? CManager.RESULTADO_WCF.ERROR : CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/CreateProduct")]
        [HttpPost]
        public BE_Json CreateProduct([FromBody]BE_Product bE_Product)
        {

            logger.Debug("Ingresando CreateProduct step 1 :  " + JsonConvert.SerializeObject(bE_Product) );
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                logger.Debug("CreateProduct step 2");
                objListaAux = JsonConvert.SerializeObject(bL_Product.CreateProduct(bE_Product));
                logger.Debug("CreateProduct step 3");
                objJson = new BE_Json();
                objJson.data = (objListaAux == "null") ? "No de pudo crear el producto: El código ya existe" : objListaAux;
                objJson.status = (objListaAux=="null")?CManager.RESULTADO_WCF.ERROR:CManager.RESULTADO_WCF.OK;
                logger.Debug("CreateProduct step 4");

            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "CreateProduct " + ex.Message );
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            logger.Debug("CreateProduct step 5");

            return objJson;

        }

        [Route("api/Product/UpdateProduct")]
        [HttpPost]
        public BE_Json UpdateProduct([FromBody]BE_Product bE_Product)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.UpdateProduct(bE_Product));

                objJson = new BE_Json();
                objJson.data = (objListaAux == "null") ? "No se pudo editar el producto: El código ya existe" : objListaAux;
                objJson.status = (objListaAux == "null") ? CManager.RESULTADO_WCF.ERROR : CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/Product/DeleteProduct/{productId}")]
        [HttpGet]
        public BE_Json DeleteProduct(int productId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Product bL_Product = new BL_Product();
                bL_Product.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Product.DeleteProduct(productId));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        
    }
}
