using Newtonsoft.Json;
using SUIT.BE;
using SUIT.Recetas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SUIT.Controllers
{
    public class DietController : ApiController
    {
        [Route("api/Diet/GetDiet")]
        [HttpGet]
        public BE_Json GetDiet()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Diet bL_Diet = new BL_Diet();
                bL_Diet.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Diet.GetDiet());

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

        [Route("api/Diet/GetDietById/{dietId}")]
        [HttpGet]
        public BE_Json GetDietById(int dietId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Diet bL_Diet = new BL_Diet();
                bL_Diet.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Diet.GetDietById(dietId));

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

        [Route("api/Diet/GetDietByName/{name}")]
        [HttpGet]
        public BE_Json GetDietByName(string name)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Diet bL_Diet = new BL_Diet();
                bL_Diet.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Diet.GetDietByName(name));

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

        [Route("api/Diet/GetDietByHeadquartersId/{headquartersId}")]
        [HttpGet]
        public BE_Json GetDietByHeadquartersId(int headquartersId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Diet bL_Diet = new BL_Diet();
                bL_Diet.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Diet.GetDietByHeadquartersId(headquartersId));

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
