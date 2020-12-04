using Newtonsoft.Json;
using SUIT.BE;
using SUIT.Recetas.BE;
using SUIT.Recetas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SUIT.Controllers
{
    public class ProductCategoryController : ApiController
    {

        [Route("api/ProductCategory/GetProductCategory")]
        [HttpGet]
        public BE_Json GetProductCategory()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_ProductCategory bL_ProductCategory = new BL_ProductCategory();
                bL_ProductCategory.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_ProductCategory.GetProductCategory());

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

        [Route("api/ProductCategory/GetProductCategoryById/{productCategoryId}")]
        [HttpGet]
        public BE_Json GetProductCategoryById(int productCategoryId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_ProductCategory bL_ProductCategory = new BL_ProductCategory();
                bL_ProductCategory.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_ProductCategory.GetProductCategoryById(productCategoryId));

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

        [Route("api/ProductCategory/GetProductCategoryByName/{name}")]
        [HttpGet]
        public BE_Json GetProductCategoryByName(string name)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_ProductCategory bL_ProductCategory = new BL_ProductCategory();
                bL_ProductCategory.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_ProductCategory.GetProductCategoryByName(name));

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


        [Route("api/ProductCategory/CreateProductCategory")]
        [HttpPost]
        public BE_Json CreateProductCategory([FromBody]BE_ProductCategory bE_ProductCategory)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_ProductCategory bL_ProductCategory = new BL_ProductCategory();
                bL_ProductCategory.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_ProductCategory.CreateProductCategory(bE_ProductCategory));

                objJson = new BE_Json();
                objJson.data = (objListaAux == "null") ? "No se pudo crear" : objListaAux;
                objJson.status = (objListaAux == "null") ? CManager.RESULTADO_WCF.ERROR : CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;

        }

        [Route("api/ProductCategory/UpdateProductCategory")]
        [HttpPost]
        public BE_Json UpdateProductCategory([FromBody]BE_ProductCategory bE_ProductCategory)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_ProductCategory bL_ProductCategory = new BL_ProductCategory();
                bL_ProductCategory.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_ProductCategory.UpdateProductCategory(bE_ProductCategory));

                objJson = new BE_Json();
                objJson.data = (objListaAux == "null") ? "No se pudo editar" : objListaAux;
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

        [Route("api/ProductCategory/DeleteProductCategory/{productCategoryId}")]
        [HttpGet]
        public BE_Json DeleteProductCategory(int productCategoryId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_ProductCategory bL_ProductCategory = new BL_ProductCategory();
                bL_ProductCategory.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_ProductCategory.DeleteProductCategory(productCategoryId));

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
