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
    public class FeedingTimeController : ApiController
    {

        [Route("api/FeedingTime/GetFeedingTime")]
        [HttpGet]
        public BE_Json GetFeedingTime()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_FeedingTime bL_FeedingTime = new BL_FeedingTime();
                bL_FeedingTime.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_FeedingTime.GetFeedingTime());

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

        [Route("api/FeedingTime/GetFeedingTimeById/{feedingTimeId}")]
        [HttpGet]
        public BE_Json GetFeedingTimeById(int feedingTimeId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_FeedingTime bL_FeedingTime = new BL_FeedingTime();
                bL_FeedingTime.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_FeedingTime.GetFeedingTimeById(feedingTimeId));

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

        [Route("api/FeedingTime/GetFeedingTimeByTypeId/{feedingTimeTypeId}")]
        [HttpGet]
        public BE_Json GetFeedingTimeByTypeId(int feedingTimeTypeId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_FeedingTime bL_FeedingTime = new BL_FeedingTime();
                bL_FeedingTime.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_FeedingTime.GetFeedingTimeByTypeId(feedingTimeTypeId));

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

        [Route("api/FeedingTime/GetFeedingTimeByDietId/{dietId}")]
        [HttpGet]
        public BE_Json GetFeedingTimeByDietId(int dietId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_FeedingTime bL_FeedingTime = new BL_FeedingTime();
                bL_FeedingTime.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_FeedingTime.GetFeedingTimeByDietId(dietId));

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

        [Route("api/FeedingTime/GetFeedingTimeByHeadquartersId/{headquartersId}")]
        [HttpGet]
        public BE_Json GetFeedingTimeByHeadquartersId(int headquartersId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_FeedingTime bL_FeedingTime = new BL_FeedingTime();
                bL_FeedingTime.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_FeedingTime.GetFeedingTimeByHeadquartersId(headquartersId));

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

        [Route("api/FeedingTime/GetFeedingTimeByDietIdAndHeadquartersId/{dietId}/{headquartersId}")]
        [HttpGet]
        public BE_Json GetFeedingTimeByDietIdAndHeadquartersId(int dietId,int headquartersId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_FeedingTime bL_FeedingTime = new BL_FeedingTime();
                bL_FeedingTime.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_FeedingTime.GetFeedingTimeByDietIdAndHeadquartersId(dietId,headquartersId));

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

        [Route("api/FeedingTime/GetFeedingTimeByName/{name}")]
        [HttpGet]
        public BE_Json GetFeedingTimeByName(string name)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_FeedingTime bL_FeedingTime = new BL_FeedingTime();
                bL_FeedingTime.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_FeedingTime.GetFeedingTimeByName(name));

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
