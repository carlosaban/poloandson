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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;


namespace SUIT.Controllers
{
    public class ProgramationController : ApiController
    {
        [Route("api/Programation/GetProgramation")]
        [HttpGet]
        public BE_Json GetProgramation()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetProgramation());

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

        [Route("api/Programation/GetProgramationById/{programationId}")]
        [HttpGet]
        public BE_Json GetProgramationById(int programationId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetProgramationById(programationId));

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

        [Route("api/Programation/GetProgramationByFilters/{month}/{headquartersId}/{dietId}")]
        [HttpGet]
        public BE_Json GetProgramationByFilters(int month, int headquartersId, int dietId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetProgramationByFilters(month,headquartersId,dietId));

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

        [Route("api/Programation/GetProgramationDetailByProgramationId/{programationId}")]
        [HttpGet]
        public BE_Json GetProgramationDetailByProgramationId(int programationId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetProgramationDetailByProgramationId(programationId));

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

        [Route("api/Programation/GetProgramationByDateAndFeedingTimeId/{date}/{feedingTime}")]
        [HttpGet]
        public BE_Json GetProgramationByDateAndFeedingTimeId(DateTime date, int feedingTime)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetProgramationByDateAndFeedingTimeId(date, feedingTime));

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


        [Route("api/Programation/GetProgramationDetailByDateAndFeedingTimeId/{date}/{feedingTime}")]
        [HttpGet]
        public BE_Json GetProgramationDetailByDateAndFeedingTimeId(DateTime date, int feedingTime)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetProgramationDetailByDateAndFeedingTimeId(date, feedingTime));

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

        [Route("api/Programation/GetProgramationResumen/{year}/{month}/{headquartersId}/{dietId}")]
        [HttpGet]
        public BE_Json GetProgramationResumen(int year, int month, int headquartersId, int dietId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetProgramationResumen(year, month, headquartersId, dietId));

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

        [Route("api/Programation/GetCategoryByProgramation/{year}/{month}/{headquartersId}/{dietId}")]
        [HttpGet]
        public BE_Json GetCategoryByProgramation(int year, int month, int headquartersId, int dietId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetCategoryByProgramation(year, month, headquartersId, dietId));

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

        //GetProductByCategoryByProgramation
        [Route("api/Programation/GetProductByCategoryByProgramation/{productCategoryId}/{year}/{month}/{headquartersId}/{dietId}/{week?}")]
        [HttpGet]
        public BE_Json GetProductByCategoryByProgramation(int productCategoryId , int year, int month, int headquartersId, int dietId , int week)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetProductByCategoryByProgramation(productCategoryId, year, month, headquartersId, dietId,week ));

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



        [Route("api/Programation/CreateProgramation")]
        [HttpPost]
        public BE_Json CreateProgramation([FromBody]BE_Programation bE_Programation)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.CreateProgramation(bE_Programation));

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

        [Route("api/Programation/UpdateProgramation")]
        [HttpPost]
        public BE_Json UpdateProgramation([FromBody]BE_Programation bE_Programation)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.UpdateProgramation(bE_Programation));

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

        [Route("api/Programation/ProgramationPdf/{year}/{month}/{headquartersId}/{dietId}/{userName}")]
        [HttpGet]
        public HttpResponseMessage ProgramationPdf(int year, int month, int headquartersId, int dietId, string userName)
        {
            BL_Programation bL_Programation = new BL_Programation();
            bL_Programation.connectionString = AppConfig.DbConnection;

            
            var date = DateTime.Now.ToString(BE.n.util.CustomeDateFormat());
            var OutputPath = "reporte"+ date + ".pdf";


            var html = bL_Programation.GetPdfData(year, month, headquartersId, dietId,userName);

            StringReader sr = new StringReader(html);
            HttpResponseMessage response = new HttpResponseMessage();

            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();


                response.StatusCode = HttpStatusCode.OK;
                response.Content = new ByteArrayContent(memoryStream.ToArray());
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = OutputPath
                };

                return response;
            }

        }

        [Route("api/Programation/ProgramationByWeekPdf/{year}/{month}/{headquartersId}/{dietId}/{userName}/{week}")]
        [HttpGet]
        public HttpResponseMessage ProgramationByWeekPdf(int year, int month, int headquartersId, int dietId, string userName,int week)
        {
            BL_Programation bL_Programation = new BL_Programation();
            bL_Programation.connectionString = AppConfig.DbConnection;


            var date = DateTime.Now.ToString(BE.n.util.CustomeDateFormat());
            var OutputPath = "reporte" + date + ".pdf";


            var html = bL_Programation.GetPdfDataByWeek(year,month, headquartersId, dietId, userName, week);

            StringReader sr = new StringReader(html);
            HttpResponseMessage response = new HttpResponseMessage();

            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();


                response.StatusCode = HttpStatusCode.OK;
                response.Content = new ByteArrayContent(memoryStream.ToArray());
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = OutputPath
                };

                return response;
            }

        }

        [Route("api/Programation/ProgramationExcel/{year}/{month}/{headquartersId}/{dietId}/{userName}")]
        [HttpGet]
        public HttpResponseMessage exportExcel(int year, int month, int headquartersId, int dietId, string userName)
        {
            BL_Programation bL_Programation = new BL_Programation();
            bL_Programation.connectionString = AppConfig.DbConnection;


            var date = DateTime.Now.ToString(BE.n.util.CustomeDateFormat());
            var OutputPath = "reporte" + date + ".xlsx";


            var ms = bL_Programation.GetExcelData(year,month, headquartersId, dietId, userName);


            HttpResponseMessage response = new HttpResponseMessage();
            
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = OutputPath
            };
            return response;
        }

        [Route("api/Programation/GetRequestResumen/{month}/{headquartersId}/{dietId}")]
        [HttpGet]
        public BE_Json GetRequestResumen( int month, int headquartersId, int dietId)
        {
            return this.GetRequestResumen(DateTime.Now.Year, month, headquartersId, dietId);

        }
        [Route("api/Programation/GetRequestResumen/{year}/{month}/{headquartersId}/{dietId}")]
        [HttpGet]
        public BE_Json GetRequestResumen(int year , int month, int headquartersId, int dietId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Programation bL_Programation = new BL_Programation();
                bL_Programation.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Programation.GetRequestResumen(year ,month, headquartersId, dietId));

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
