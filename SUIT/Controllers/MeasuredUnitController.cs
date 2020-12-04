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
    public class MeasuredUnitController : ApiController
    {

        [Route("api/MeasuredUnit/GetMeasuredUnitGeneral")]
        [HttpPost]
        public BE_Json GetMeasuredUnit([FromBody] BE_MeasuredUnit BE_MeasuredUnit )
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_MeasuredUnit bL_MeasuredUnit = new BL_MeasuredUnit();
                bL_MeasuredUnit.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_MeasuredUnit.GetMeasuredUnitGeneral(BE_MeasuredUnit));

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

        [Route("api/MeasuredUnit/GetMeasuredUnit")]
        [HttpGet]
        public BE_Json GetMeasuredUnit()
        {
            return this.GetMeasuredUnit(new BE_MeasuredUnit() { isEnabled = true, isBase = null });
            //BE_Json objJson = null;
            //var objListaAux = string.Empty;
            //try
            //{
            //    BL_MeasuredUnit bL_MeasuredUnit = new BL_MeasuredUnit();
            //    bL_MeasuredUnit.connectionString = AppConfig.DbConnection;
            //    objListaAux = JsonConvert.SerializeObject(bL_MeasuredUnit.GetMeasuredUnit());

            //    objJson = new BE_Json();
            //    objJson.data = objListaAux;
            //    objJson.status = CManager.RESULTADO_WCF.OK;
            //}
            //catch (Exception ex)
            //{
            //    objJson = new BE_Json();
            //    objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
            //    objJson.status = CManager.RESULTADO_WCF.ERROR;
            //    objJson.status = CManager.RESULTADO_WCF.ERROR;
            //}
            //finally
            //{
            //    objListaAux = null;
            //}
            //return objJson;

        }

        [Route("api/MeasuredUnit/GetMeasuredUnitById/{measuredUnitId}/{isBase?}")]
        [HttpGet]
        public BE_Json GetMeasuredUnitById(int measuredUnitId , bool? isBase = null)
        {
            return this.GetMeasuredUnit(new BE_MeasuredUnit() { isEnabled = true, measuredUnitId = measuredUnitId, isBase = isBase });
            //BE_Json objJson = null;
            //var objListaAux = string.Empty;
            //try
            //{
            //    BL_MeasuredUnit bL_MeasuredUnit = new BL_MeasuredUnit();
            //    bL_MeasuredUnit.connectionString = AppConfig.DbConnection;
            //    objListaAux = JsonConvert.SerializeObject(bL_MeasuredUnit.GetMeasuredUnitById(measuredUnitId));

            //    objJson = new BE_Json();
            //    objJson.data = objListaAux;
            //    objJson.status = CManager.RESULTADO_WCF.OK;
            //}
            //catch (Exception ex)
            //{
            //    objJson = new BE_Json();
            //    objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
            //    objJson.status = CManager.RESULTADO_WCF.ERROR;
            //    objJson.status = CManager.RESULTADO_WCF.ERROR;
            //}
            //finally
            //{
            //    objListaAux = null;
            //}
            //return objJson;

        }

        [Route("api/MeasuredUnit/GetMeasuredUnitByName/{name}")]
        [HttpGet]
        public BE_Json GetMeasuredUnitByName(string name)
        {
            return this.GetMeasuredUnit(new BE_MeasuredUnit() {isEnabled = true,name = name });
            //BE_Json objJson = null;
            //var objListaAux = string.Empty;
            //try
            //{
            //    BL_MeasuredUnit bL_MeasuredUnit = new BL_MeasuredUnit();
            //    bL_MeasuredUnit.connectionString = AppConfig.DbConnection;
            //    objListaAux = JsonConvert.SerializeObject(bL_MeasuredUnit.GetMeasuredUnitByName(name));

            //    objJson = new BE_Json();
            //    objJson.data = objListaAux;
            //    objJson.status = CManager.RESULTADO_WCF.OK;
            //}
            //catch (Exception ex)
            //{
            //    objJson = new BE_Json();
            //    objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
            //    objJson.status = CManager.RESULTADO_WCF.ERROR;
            //    objJson.status = CManager.RESULTADO_WCF.ERROR;
            //}
            //finally
            //{
            //    objListaAux = null;
            //}
            //return objJson;

        }


        [Route("api/MeasuredUnit/CreateMeasuredUnit")]
        [HttpPost]
        public BE_Json CreateMeasuredUnit([FromBody]BE_MeasuredUnit bE_MeasuredUnit)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_MeasuredUnit bL_MeasuredUnit = new BL_MeasuredUnit();
                bL_MeasuredUnit.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_MeasuredUnit.CreateMeasuredUnit(bE_MeasuredUnit));

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

        [Route("api/MeasuredUnit/UpdateMeasuredUnit")]
        [HttpPost]
        public BE_Json UpdateMeasuredUnit([FromBody]BE_MeasuredUnit bE_MeasuredUnit)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_MeasuredUnit bL_MeasuredUnit = new BL_MeasuredUnit();
                bL_MeasuredUnit.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_MeasuredUnit.UpdateMeasuredUnit(bE_MeasuredUnit));

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

        [Route("api/MeasuredUnit/DeleteMeasuredUnit/{measuredUnitId}")]
        [HttpGet]
        public BE_Json DeleteMeasuredUnit(int measuredUnitId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_MeasuredUnit bL_MeasuredUnit = new BL_MeasuredUnit();
                bL_MeasuredUnit.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_MeasuredUnit.DeleteMeasuredUnit(measuredUnitId));

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
