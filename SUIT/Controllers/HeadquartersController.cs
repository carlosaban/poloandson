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
    public class HeadquartersController : ApiController
    {
        [Route("api/Headquarters/GetHeadquarters")]
        [HttpGet]
        public BE_Json GetHeadquarters()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Headquarters bL_Headquarters = new BL_Headquarters();
                bL_Headquarters.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Headquarters.GetHeadquarters());

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

        [Route("api/Headquarters/GetHeadquartersById/{headquartersId}")]
        [HttpGet]
        public BE_Json GetHeadquartersById(int headquartersId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Headquarters bL_Headquarters = new BL_Headquarters();
                bL_Headquarters.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Headquarters.GetHeadquartersById(headquartersId));

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

        [Route("api/Headquarters/GetHeadquartersByTypeId/{headquartersTypeId}")]
        [HttpGet]
        public BE_Json GetHeadquartersByTypeId(int headquartersTypeId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Headquarters bL_Headquarters = new BL_Headquarters();
                bL_Headquarters.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Headquarters.GetHeadquartersByTypeId(headquartersTypeId));

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

        [Route("api/Headquarters/GetHeadquartersByName/{name}")]
        [HttpGet]
        public BE_Json GetHeadquartersByName(string name)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Headquarters bL_Headquarters = new BL_Headquarters();
                bL_Headquarters.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Headquarters.GetHeadquartersByName(name));

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

        [Route("api/Headquarters/GetConsolidated/{year}/{month}/{sede?}")]
        [HttpGet]
        public BE_Json GetConsolidatedReport(int year, int month , int sede =0)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Headquarters bL_Headquarters = new BL_Headquarters();
                bL_Headquarters.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Headquarters.GetConsolidatedReport(year, month , sede));

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
