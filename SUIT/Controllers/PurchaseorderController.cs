using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SUIT.BL;
using SUIT.Pago.BL;
using SUIT.Pago.BE;
using SUIT.BE;
using Newtonsoft.Json;
using SUIT.Security.BE;
using SUIT.Security.BL;
using SUIT.Security.BE.Filters;
using SUIT.ViewModel;
using SUIT.Recetas.BE;
using SUIT.Recetas.BL;

namespace SUIT.Controllers.APIController
{
    //[Route("api/[controller]")]

    public class PurchaseorderController : ApiController
    {

        /*-------------------------------GET UserController-----------------------------*/



  
     
        [Route("api/Purchaseorder/Get/{idDocumentType}")]
        [HttpGet]
        public BE_Json Get(string idDocumentType)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetUserRoleId();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Schedule _blSchedule = new BL_Schedule();
                _blSchedule.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blSchedule.GetScheduleGeneral(new BE_Schedule() {  } ));

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



        [Route("api/Purchaseorder/Get/{idDocumentType}/{CompanyCode}/{programationId}/{DocumentId}/{InvoiceStatudId}")]
        [HttpGet]
        public BE_Json Get(string idDocumentType,string CompanyCode, string programationId ,string DocumentId, int InvoiceStatudId)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetUserRoleId();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Schedule _blSchedule = new BL_Schedule();
                _blSchedule.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blSchedule.GetScheduleGeneral( new BE_Schedule() { }));

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


        [Route("api/Purchaseorder/Insert")]
        [HttpPost]
        public BE_Json Insert([FromBody] BE_Schedule bE_Schedule)
        {
           

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Schedule _blSchedule = new BL_Schedule();
                _blSchedule.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blSchedule.CreateSchedule(bE_Schedule));

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
        [Route("api/Purchaseorder/Update")]
        [HttpPost]
        public BE_Json Update([FromBody]BE_Schedule bE_Schedule)
        {


            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Schedule _blSchedule = new BL_Schedule();
                _blSchedule.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blSchedule.UpdateSchedule(bE_Schedule));

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
