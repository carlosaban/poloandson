using SUIT.BE.n;
using SUIT.Recetas.BE;
using SUIT.Recetas.DA;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace SUIT.Recetas.BL
{
    public class BL_Programation
    {
        public MySQLDatabase _database;
        public string connectionString;

        private List<BE_Programation> GetProgramationGeneral(int programationId, int month, int headquartersId, int dietId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Programation(_database).GetProgramationGeneral(programationId,month,headquartersId,dietId);
        }

        public List<BE_Programation> GetProgramation()
        {
            _database = new MySQLDatabase(connectionString);
            return GetProgramationGeneral(0,0,0,0);
        }

        public List<BE_Programation> GetProgramationById(int programationId)
        {
            _database = new MySQLDatabase(connectionString);
            return GetProgramationGeneral(programationId, 0, 0, 0);
        }

        public List<BE_Programation> GetProgramationByFilters(int month, int headquartersId, int dietId)
        {
            _database = new MySQLDatabase(connectionString);
            return GetProgramationGeneral(0,month, headquartersId, dietId);
        }

        public List<VE_ProgramationDetail> GetProgramationDetailByProgramationId(int programationId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Programation(_database).GetProgramationDetailByProgramationId(programationId);
        }

        public BE_Programation GetProgramationByDateAndFeedingTimeId(DateTime date, int feedingTimeId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Programation(_database).GetProgramationByDateAndFeedingTimeId(date, feedingTimeId);
        }

        public List<VE_ProgramationDetail> GetProgramationDetailByDateAndFeedingTimeId(DateTime date,int feedingTimeId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Programation(_database).GetProgramationDetailByDateAndFeedingTimeId(date, feedingTimeId);
        }

        public BE_Programation CreateProgramation(BE_Programation bE_Programation)
        {
            _database = new MySQLDatabase(connectionString);
            var newProgramation = new DA_Programation(_database).CreateProgramation(bE_Programation);
            if (newProgramation.detail != null)
            {
                foreach (var detail in newProgramation.detail)
                {
                    detail.programationId = newProgramation.programationId;
                    CreateProgramationDetail(detail);
                }
            }
            return newProgramation;
        }

        private BE_ProgramationDetail CreateProgramationDetail(BE_ProgramationDetail bE_ProgramationDetail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Programation(_database).CreateProgramationDetail(bE_ProgramationDetail);
        }

        private int DeleteProgramationDetailByProgramationId(int programationId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Programation(_database).DeleteProgramationDetailByProgramationId(programationId);
        }


        public BE_Programation UpdateProgramation(BE_Programation bE_Programation)
        {
            _database = new MySQLDatabase(connectionString);
            
            var updatedProgramation = new DA_Programation(_database).UpdateProgramation(bE_Programation);

            if (updatedProgramation.detail != null)
            {
                DeleteProgramationDetailByProgramationId(updatedProgramation.programationId);
                foreach (var detail in updatedProgramation.detail)
                {
                    detail.programationId = updatedProgramation.programationId;
                    CreateProgramationDetail(detail);
                }
            }
            return updatedProgramation;
        }

        public List<ProgramationResumenByWeekOfMonth> GetProgramationResumen(int month, int headquartersId, int dietId)
        {
            int year = DateTime.Now.Year;
            return GetProgramationResumen(year, month, headquartersId, dietId);
        }

        public List<ProgramationResumenByWeekOfMonth> GetProgramationResumen(int year, int month, int headquartersId, int dietId)
        {

            _database = new MySQLDatabase(connectionString);

            var listProgramation = new DA_Programation(_database).GetProgramationResumen(year , month, headquartersId, dietId);


            List<ProgramationByWeekOfMonth> ListProgramationByWeek = new List<ProgramationByWeekOfMonth>();
            List<ProgramationResumenByWeekOfMonth> ListProgramationResumenByWeek = new List<ProgramationResumenByWeekOfMonth>();

            util _util = new util();

            foreach (var item in listProgramation)
            {
                var validate = ListProgramationByWeek.Find(x => x.WeekOfMonth.WeekOfMonth == item.weekOfMonth);
                if (validate == null)
                {
                    ProgramationByWeekOfMonth pwm = new ProgramationByWeekOfMonth();
                    pwm.WeekOfMonth = _util.GetWeekOfMonth(item.date);
                    pwm.listProgramation.Add(item);
                    ListProgramationByWeek.Add(pwm);
                }
                else
                {
                    ListProgramationByWeek.Find(x => x.WeekOfMonth.WeekOfMonth == item.weekOfMonth).listProgramation.Add(item);
                }
            }

            List<ProgramationResumen> lpr = null;

            foreach (var listByWeek in ListProgramationByWeek)
            {
                lpr = new List<ProgramationResumen>();
                
                ProgramationResumen pr = null;

                foreach (var item in listByWeek.listProgramation)
                {
                    pr = new ProgramationResumen();
                    var validFeedingTimeId = lpr.Find(x => x.feedingTimeId == item.feedingTimeId);
                    if (validFeedingTimeId == null)
                    {
                        pr.feedingTimeId = item.feedingTimeId;
                        pr.feedingTimeName = item.feedingTimeName;
                        pr.monday.date = listByWeek.WeekOfMonth.MondayDate;
                        pr.monday.dateFormat = listByWeek.WeekOfMonth.MondayDateFormat;
                        pr.tuesday.date = listByWeek.WeekOfMonth.TuesdayDate;
                        pr.tuesday.dateFormat = listByWeek.WeekOfMonth.TuesdayDateFormat;
                        pr.wednesday.date = listByWeek.WeekOfMonth.WednesdayDate;
                        pr.wednesday.dateFormat = listByWeek.WeekOfMonth.WednesdayDateFormat;
                        pr.thursday.date = listByWeek.WeekOfMonth.ThursdayDate;
                        pr.thursday.dateFormat = listByWeek.WeekOfMonth.ThursdayDateFormat;
                        pr.friday.date = listByWeek.WeekOfMonth.FridayDate;
                        pr.friday.dateFormat = listByWeek.WeekOfMonth.FridayDateFormat;
                        pr.saturday.date = listByWeek.WeekOfMonth.SaturdayDate;
                        pr.saturday.dateFormat = listByWeek.WeekOfMonth.SaturdayDateFormat;
                        pr.sunday.date = listByWeek.WeekOfMonth.SundayDate;
                        pr.sunday.dateFormat = listByWeek.WeekOfMonth.SundayDateFormat;
                        switch (item.dayOfWeek)
                        {
                            case DayOfWeek.Monday: pr.monday.programation.Add(item);break;
                            case DayOfWeek.Tuesday: pr.tuesday.programation.Add(item);break;
                            case DayOfWeek.Wednesday: pr.wednesday.programation.Add(item);break;
                            case DayOfWeek.Thursday: pr.thursday.programation.Add(item);break;
                            case DayOfWeek.Friday: pr.friday.programation.Add(item);break;
                            case DayOfWeek.Saturday: pr.saturday.programation.Add(item);break;
                            case DayOfWeek.Sunday: pr.sunday.programation.Add(item);break;
                        }

                        lpr.Add(pr);
                    }
                    else
                    {
                        switch (item.dayOfWeek)
                        {
                            case DayOfWeek.Monday: lpr.Find(x => x.feedingTimeId == item.feedingTimeId).monday.programation.Add(item); break;
                            case DayOfWeek.Tuesday: lpr.Find(x => x.feedingTimeId == item.feedingTimeId).tuesday.programation.Add(item); break;
                            case DayOfWeek.Wednesday: lpr.Find(x => x.feedingTimeId == item.feedingTimeId).wednesday.programation.Add(item); break;
                            case DayOfWeek.Thursday: lpr.Find(x => x.feedingTimeId == item.feedingTimeId).thursday.programation.Add(item); break;
                            case DayOfWeek.Friday: lpr.Find(x => x.feedingTimeId == item.feedingTimeId).friday.programation.Add(item); break;
                            case DayOfWeek.Saturday: lpr.Find(x => x.feedingTimeId == item.feedingTimeId).saturday.programation.Add(item); break;
                            case DayOfWeek.Sunday: lpr.Find(x => x.feedingTimeId == item.feedingTimeId).sunday.programation.Add(item); break;
                        }
                    }
                }

                ProgramationResumenByWeekOfMonth prwm = new ProgramationResumenByWeekOfMonth();
                prwm.WeekOfMonth = listByWeek.WeekOfMonth;
                prwm.listProgramation = lpr;
                ListProgramationResumenByWeek.Add(prwm);

            }

            List<ProgramationResumenByWeekOfMonth> orderList = ListProgramationResumenByWeek.OrderBy(x => x.WeekOfMonth.WeekOfMonth).ToList();

            return orderList;
            
        }


        public List<BEReportCategoryByProgramationView> GetCategoryByProgramation(int year, int month, int headquartersId, int dietId)
        {

            _database = new MySQLDatabase(connectionString);

            List <BEReportCategoryByProgramationView> listProgramation = new DA_Programation(_database).GetCategoryByProgramation(year, month, headquartersId, dietId);


           
            return listProgramation;

        }

        public List<BEReportPodructCategoryByProgramationView> GetProductByCategoryByProgramation(int productCategoryId , int year, int month, int headquartersId, int dietId, int week)
        {

            _database = new MySQLDatabase(connectionString);

            List<BEReportPodructCategoryByProgramationView> listProgramation = new DA_Programation(_database).GetProductByCategoryByProgramation(productCategoryId , year, month, headquartersId, dietId, week);



            return listProgramation;

        }

        public List<RequestResumenByWeekOfMonth> GetRequestResumen(int month, int headquartersId, int dietId)
        {
            int year = DateTime.Now.Year;
            return GetRequestResumen(year, month , headquartersId, dietId);

        }
        public List<RequestResumenByWeekOfMonth> GetRequestResumen(int year , int month, int headquartersId, int dietId)
        {

            _database = new MySQLDatabase(connectionString);

            var listProgramationDetail = new DA_Programation(_database).GetProgramationDetailResumen(year, month, headquartersId, dietId);


            List<RequestResumenByWeekOfMonth> ListRequestResumenByWeek = new List<RequestResumenByWeekOfMonth>();
            List<RequestResumen> ListRequestResumen = new List<RequestResumen>();
            List<RequestByWeekOfMonth> ListRequestByWeekOfMonth = new List<RequestByWeekOfMonth>();

            util _util = new util();

            foreach (var item in listProgramationDetail)
            {
                var validate = ListRequestByWeekOfMonth.Find(x => x.WeekOfMonth.WeekOfMonth == item.weekOfMonth);
                if (validate == null)
                {
                    RequestByWeekOfMonth rwm = new RequestByWeekOfMonth();
                    rwm.WeekOfMonth = _util.GetWeekOfMonth(item.date);
                    rwm.listRequest.Add(item);
                    ListRequestByWeekOfMonth.Add(rwm);
                }
                else
                {
                    ListRequestByWeekOfMonth.Find(x => x.WeekOfMonth.WeekOfMonth == item.weekOfMonth).listRequest.Add(item);
                }
            }

            List<RequestResumen> lrr = null;

            foreach (var listByWeek in ListRequestByWeekOfMonth)
            {
                lrr = new List<RequestResumen>();

                RequestResumen rr = null;
                decimal totalToWeek = 0;


                foreach (var item in listByWeek.listRequest)
                {
                    rr = new RequestResumen();
                    var validProductCategoryId = lrr.Find(x => x.productCategoryId == item.productCategoryId);
                    if (validProductCategoryId == null)
                    {
                        rr.headquartersName = item.headquartersName;
                        rr.dietName = item.dietName;
                        rr.productCategoryId = item.productCategoryId;
                        rr.productCategoryName = item.productCategoryName;
                        rr.amount = item.productCost;
                        rr.dateFormat = item.dateFormat;
                        totalToWeek+= item.productCost;
                        lrr.Add(rr);
                    }
                    else
                    {
                        lrr.Find(x => x.productCategoryId == item.productCategoryId).amount+=item.productCost;
                        totalToWeek += item.productCost;
                    }
                }

                
                foreach(var p in lrr)
                {
                    p.percentage = (totalToWeek==0) ? 0 : Math.Round((p.amount/totalToWeek) * 100,2);
                }


                RequestResumenByWeekOfMonth rrwm = new RequestResumenByWeekOfMonth();
                rrwm.WeekOfMonth = listByWeek.WeekOfMonth;
                rrwm.listRequest = lrr;
                ListRequestResumenByWeek.Add(rrwm);

            }

            List<RequestResumenByWeekOfMonth> orderList = ListRequestResumenByWeek.OrderBy(x => x.WeekOfMonth.WeekOfMonth).ToList();

            return orderList;

        }

        public string GetPdfDataByWeek(int month, int headquartersId, int dietId, string userName, int weekOfMonth)
        {
            return GetPdfDataByWeek(DateTime.Now.Year, month, headquartersId, dietId, userName, weekOfMonth);
        }

        public string GetPdfDataByWeek(int year , int month, int headquartersId, int dietId, string userName,int weekOfMonth)
        {
            List<ProgramationResumenByWeekOfMonth> listResumenByWeekOfMonth = GetProgramationResumen(year , month, headquartersId, dietId);

            var filter = listResumenByWeekOfMonth.Find(x => x.WeekOfMonth.WeekOfMonth == weekOfMonth);

            
            List<ProgramationResumenByWeekOfMonth> newList = new List<ProgramationResumenByWeekOfMonth>();
            if (filter != null)
            {
                newList.Add(filter);
            }
            var html = GetPdfData(year, month, headquartersId, dietId, userName, newList);
            return html;
        }
        public string GetPdfData(int month, int headquartersId, int dietId, string userName)
        {
            return GetPdfData(DateTime.Now.Year, month, headquartersId, dietId, userName);
        }

        public string GetPdfData(int year , int month, int headquartersId, int dietId, string userName )
        {
            var html = GetPdfData(year, month, headquartersId, dietId, userName, null);

            return html;
        }
        public string GetPdfData(int month, int headquartersId, int dietId, string userName, List<ProgramationResumenByWeekOfMonth> listResumenByWeekOfMonth)
        {
            return GetPdfData(DateTime.Now.Year, month, headquartersId, dietId, userName, listResumenByWeekOfMonth);
        }

        public string GetPdfData(int year , int month, int headquartersId, int dietId,string userName, List<ProgramationResumenByWeekOfMonth> listResumenByWeekOfMonth)
        {
            if (listResumenByWeekOfMonth == null)
            {
                listResumenByWeekOfMonth = GetProgramationResumen(year, month, headquartersId, dietId);
            }

            BL_Headquarters bL_Headquarters= new BL_Headquarters();
            bL_Headquarters.connectionString = connectionString;
            var headquartersList = bL_Headquarters.GetHeadquartersById(headquartersId);
            BE_Headquarters headquarters = new BE_Headquarters();
            if (headquartersList.Count>0)
            {
                headquarters = headquartersList[0];
            }


            BL_Diet bL_Diet = new BL_Diet();
            bL_Diet.connectionString = connectionString;
            var dietList = bL_Diet.GetDietById(dietId);
            BE_Diet diet = new BE_Diet();
            if (dietList.Count > 0)
            {
                diet = dietList[0];
            }




            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang=\"en\">");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset=\"UTF - 8\">");
            html.AppendLine("<meta name=\"viewport\" content=\"width = device - width, initial - scale = 1.0\">");
            html.AppendLine("<meta http-equiv=\"X - UA - Compatible\" content=\"ie = edge\">");
            html.AppendLine("</head>");
            html.AppendLine("<body style=\"background-color: crimson; \">");
            html.AppendLine("<header>");
            html.AppendLine("<table style=\"border - color: black; width: 100 %; margin - top: 10px; \">");
            html.AppendLine("<tr>");
            html.AppendLine("<td><img src=\"http://polo.dev.erp.suit.pe/assets/logo-polo.png\" width=\"200px\"></td>");
            html.AppendLine("<td  align=\"right\"><h2 style=\"color: black; font - family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans - serif;font-size: 10px \">Fecha: @Fecha<br/>Usuario: @Usuario</h2></td>");
            html.AppendLine("</tr>");
            html.AppendLine("<tr>");
            html.AppendLine("<td><h1 style=\"color: crimson; font - family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans - serif; \">Reporte programación</h1></td>");
            html.AppendLine("<td></td>");
            html.AppendLine("</tr>");
            html.AppendLine("</table>");
            html.AppendLine("<br/>");
            html.AppendLine("<table border=\"1\" style=\"border - color: black; width: 100 % \"><tr><td>&nbsp;</td></tr></table>");
            html.AppendLine("<br/>");
            html.AppendLine("<table style=\"border - color: black; width: 100 %; margin - top: 10px; \">");
            html.AppendLine("<tr>");
            html.AppendLine("<th style=\"color: black; \">Sede: @Sede</th>");
            html.AppendLine("<th style=\"color: black; \">Dieta: @Dieta</th>");
            html.AppendLine("<th style=\"color: black; \">Mes: @Mes</th>");
            html.AppendLine("</tr>");
            html.AppendLine("</table>");

            html.AppendLine("<br/>");
            html.AppendLine("</header>");
            

            foreach (var resumenByWeekOfMonth in listResumenByWeekOfMonth)
            {

                html.AppendLine("<table border=\"1\" style=\"border-color: black; width: 100 %;\">");
                html.AppendLine("<tr>");
                html.AppendLine("<th>T.A.</th>");

                var sabado = (resumenByWeekOfMonth.WeekOfMonth.SaturdayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.SaturdayDate.Day.ToString();
                html.AppendLine("<th>Sabado " + sabado + "</th>");

                var domingo = (resumenByWeekOfMonth.WeekOfMonth.SundayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.SundayDate.Day.ToString();
                html.AppendLine("<th>Domingo " + domingo + "</th>");

                var lunes = (resumenByWeekOfMonth.WeekOfMonth.MondayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.MondayDate.Day.ToString();
                html.AppendLine("<th>Lunes " + lunes + "</th>");

                var martes = (resumenByWeekOfMonth.WeekOfMonth.TuesdayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.TuesdayDate.Day.ToString();
                html.AppendLine("<th>Martes " + martes + "</th>");

                var miercoles = (resumenByWeekOfMonth.WeekOfMonth.WednesdayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.WednesdayDate.Day.ToString();
                html.AppendLine("<th>Miercoles " + miercoles + "</th>");

                var jueves = (resumenByWeekOfMonth.WeekOfMonth.ThursdayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.ThursdayDate.Day.ToString();
                html.AppendLine("<th>Jueves " + jueves + "</th>");

                var viernes = (resumenByWeekOfMonth.WeekOfMonth.FridayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.FridayDate.Day.ToString();
                html.AppendLine("<th>Viernes " + viernes + "</th>");

                html.AppendLine("</tr>");
                
                foreach(var resumen in resumenByWeekOfMonth.listProgramation)
                {
                    html.AppendLine("<tr>");
                    html.AppendLine("<td>@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "|Tiempo" + resumen.feedingTimeId + "</td>");
                    html.AppendLine("<td>@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Sabado</td>");
                    html.AppendLine("<td>@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Domingo</td>");
                    html.AppendLine("<td>@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Lunes</td>");
                    html.AppendLine("<td>@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Martes</td>");
                    html.AppendLine("<td>@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Miercoles</td>");
                    html.AppendLine("<td>@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Jueves</td>");
                    html.AppendLine("<td>@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Viernes</td>");
                    html.AppendLine("</tr>");
                }
                html.AppendLine("</table>");
                html.AppendLine("<br/>");
            }
            html.AppendLine("</body>");
            html.AppendLine("</html>");


            html.Replace("@Sede", headquarters.name);
            html.Replace("@Dieta", diet.name);
            html.Replace("@Mes", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)));
            html.Replace("@Fecha", DateTime.Now.ToShortDateString());
            html.Replace("@Usuario", userName);
            
            foreach (var resumenByWeekOfMonth in listResumenByWeekOfMonth)
            {

                foreach (var resumen in resumenByWeekOfMonth.listProgramation)
                {
                    html.Replace("@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "|Tiempo" + resumen.feedingTimeId,resumen.feedingTimeName);
                    
                    StringBuilder monday = new StringBuilder();
                    foreach (var r in resumen.monday.programation)
                    {
                        monday.AppendLine("<p>" + r.productName + "</p>");
                    }
                    html.Replace("@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Lunes", monday.ToString());

                    StringBuilder tuesday = new StringBuilder();
                    foreach (var r in resumen.tuesday.programation)
                    {
                        tuesday.AppendLine("<p>" + r.productName + "</p>");
                    }
                    html.Replace("@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Martes", tuesday.ToString());

                    StringBuilder wednesday = new StringBuilder();
                    foreach (var r in resumen.wednesday.programation)
                    {
                        wednesday.AppendLine("<p>" + r.productName + "</p>");
                    }
                    html.Replace("@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Miercoles", wednesday.ToString());

                    StringBuilder thursday = new StringBuilder();
                    foreach (var r in resumen.thursday.programation)
                    {
                        thursday.AppendLine("<p>" + r.productName + "</p>");
                    }
                    html.Replace("@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Jueves", thursday.ToString());

                    StringBuilder friday = new StringBuilder();
                    foreach (var r in resumen.friday.programation)
                    {
                        friday.AppendLine("<p>" + r.productName + "</p>");
                    }
                    html.Replace("@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Viernes", friday.ToString());

                    StringBuilder saturday = new StringBuilder();
                    foreach (var r in resumen.saturday.programation)
                    {
                        saturday.AppendLine("<p>" + r.productName + "</p>");
                    }
                    html.Replace("@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Sabado", saturday.ToString());

                    StringBuilder sunday = new StringBuilder();
                    foreach (var r in resumen.sunday.programation)
                    {
                        sunday.AppendLine("<p>" + r.productName + "</p>");
                    }
                    html.Replace("@Rango" + resumenByWeekOfMonth.WeekOfMonth.WeekOfMonth + "-Tiempo" + resumen.feedingTimeId + "|Domingo", sunday.ToString());

                }
            }

            return html.ToString();
        }

        public MemoryStream GetExcelData(int month, int headquartersId, int dietId, string userName) {

            return GetExcelData(DateTime.Now.Year , month, headquartersId,dietId,userName);
        }
        public MemoryStream GetExcelData(int year, int month, int headquartersId, int dietId, string userName)
        {
            MemoryStream ms = new MemoryStream();

            List<ProgramationResumenByWeekOfMonth> listResumenByWeekOfMonth = GetProgramationResumen(year, month, headquartersId, dietId);
            BL_Headquarters bL_Headquarters = new BL_Headquarters();
            bL_Headquarters.connectionString = connectionString;
            var headquartersList = bL_Headquarters.GetHeadquartersById(headquartersId);
            BE_Headquarters headquarters = new BE_Headquarters();
            if (headquartersList.Count > 0)
            {
                headquarters = headquartersList[0];
            }


            BL_Diet bL_Diet = new BL_Diet();
            bL_Diet.connectionString = connectionString;
            var dietList = bL_Diet.GetDietById(dietId);
            BE_Diet diet = new BE_Diet();
            if (dietList.Count > 0)
            {
                diet = dietList[0];
            }


            using (var p = new ExcelPackage())
            {
                var styleTitle = p.Workbook.Styles.CreateNamedStyle("styleTitle");
                styleTitle.Style.Font.Bold = true;
                styleTitle.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                styleTitle.Style.Border.Left.Color.SetColor(Color.Crimson);
                styleTitle.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                styleTitle.Style.Border.Top.Color.SetColor(Color.Crimson);
                styleTitle.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                styleTitle.Style.Border.Right.Color.SetColor(Color.Crimson);
                styleTitle.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                styleTitle.Style.Border.Bottom.Color.SetColor(Color.Crimson);


                //Estilo de la cabecera
                var styleHeader = p.Workbook.Styles.CreateNamedStyle("styleHeader");
                styleHeader.Style.Font.Bold = true;
                styleHeader.Style.Fill.PatternType = ExcelFillStyle.Solid;
                styleHeader.Style.Fill.BackgroundColor.SetColor(Color.Crimson);
                styleHeader.Style.Font.Color.SetColor(Color.White);
                                

                //Estilo del contenido
                var styleContent = p.Workbook.Styles.CreateNamedStyle("styleContent");
                styleContent.Style.Fill.PatternType = ExcelFillStyle.Solid;
                styleContent.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                styleContent.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                styleContent.Style.Border.Left.Color.SetColor(Color.Crimson);
                styleContent.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                styleContent.Style.Border.Top.Color.SetColor(Color.Crimson);
                styleContent.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                styleContent.Style.Border.Right.Color.SetColor(Color.Crimson);
                styleContent.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                styleContent.Style.Border.Bottom.Color.SetColor(Color.Crimson);


                var ws = p.Workbook.Worksheets.Add("Promagacion");


                ws.Cells["B1:F1"].Merge = true;
                ws.Cells["B1"].Value = "Polo and Sons";
                ws.Cells["B1"].Style.Font.Size = 48;
                ws.Cells["B1"].Style.Font.Bold = true;

                ws.Cells["F2"].Value = "Fecha: " + DateTime.Now.ToShortDateString();
                ws.Cells["F3"].Value = "Sede: "+ userName;

                ws.Cells["B4"].Value = "Sede: "+ headquarters.name;
                ws.Cells["C4"].Value = "Dieta: "+ diet.name;
                ws.Cells["D4"].Value = "Mes: "+CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month));


                ws.Cells[4, 2, 4, 4].StyleName = "styleTitle";
                ws.Cells[2, 6, 3, 6].StyleName = "styleTitle";





                
                //Contenidos de las tablas
                List<List<string[]>> contents = new List<List<string[]>>();

                foreach (var resumenByWeekOfMonth in listResumenByWeekOfMonth)
                {
                    List<string[]> content = new List<string[]>();

                    List<string> contentHeader = new List<string>();

                    contentHeader.Add("Tiempo de alimentación");

                    var saturdayHeader = (resumenByWeekOfMonth.WeekOfMonth.SaturdayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.SaturdayDate.Day.ToString();
                    contentHeader.Add("Sabado "+saturdayHeader);

                    var sundayHeader = (resumenByWeekOfMonth.WeekOfMonth.SundayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.SundayDate.Day.ToString();
                    contentHeader.Add("Domingo " + sundayHeader); 

                    var mondayHeader = (resumenByWeekOfMonth.WeekOfMonth.MondayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.MondayDate.Day.ToString();
                    contentHeader.Add("Lunes " + mondayHeader);

                    var tuesdayHeader = (resumenByWeekOfMonth.WeekOfMonth.TuesdayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.TuesdayDate.Day.ToString();
                    contentHeader.Add("Martes " + tuesdayHeader);

                    var wednesdayHeader = (resumenByWeekOfMonth.WeekOfMonth.WednesdayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.WednesdayDate.Day.ToString();
                    contentHeader.Add("Miercoles " + wednesdayHeader);

                    var thursdayHeader = (resumenByWeekOfMonth.WeekOfMonth.ThursdayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.ThursdayDate.Day.ToString();
                    contentHeader.Add("Jueves " + thursdayHeader);

                    var fridayHeader = (resumenByWeekOfMonth.WeekOfMonth.FridayDate.Year == 1) ? "" : resumenByWeekOfMonth.WeekOfMonth.FridayDate.Day.ToString();
                    contentHeader.Add("Viernes " + fridayHeader);

                    string[] headerRowStringArray = new string[contentHeader.Count()];
                    headerRowStringArray = contentHeader.ToArray();
                    content.Add(headerRowStringArray);


                    foreach (var resumen in resumenByWeekOfMonth.listProgramation)
                    {
                        List<string> contentRow = new List<string>();

                        contentRow.Add(resumen.feedingTimeName);


                        StringBuilder saturday = new StringBuilder();
                        foreach (var r in resumen.saturday.programation)
                        {
                            saturday.AppendLine(r.productName);
                        }
                        contentRow.Add(saturday.ToString());

                        StringBuilder sunday = new StringBuilder();
                        foreach (var r in resumen.sunday.programation)
                        {
                            sunday.AppendLine(r.productName);
                        }
                        contentRow.Add(sunday.ToString());


                        StringBuilder monday = new StringBuilder();
                        foreach (var r in resumen.monday.programation)
                        {
                            monday.AppendLine(r.productName);
                        }
                        contentRow.Add(monday.ToString());

                        StringBuilder tuesday = new StringBuilder();
                        foreach (var r in resumen.tuesday.programation)
                        {
                            tuesday.AppendLine(r.productName);
                        }
                        contentRow.Add(tuesday.ToString());

                        StringBuilder wednesday = new StringBuilder();
                        foreach (var r in resumen.wednesday.programation)
                        {
                            wednesday.AppendLine(r.productName);
                        }
                        contentRow.Add(wednesday.ToString());

                        StringBuilder thursday = new StringBuilder();
                        foreach (var r in resumen.thursday.programation)
                        {
                            thursday.AppendLine(r.productName);
                        }
                        contentRow.Add(thursday.ToString());

                        StringBuilder friday = new StringBuilder();
                        foreach (var r in resumen.friday.programation)
                        {
                            friday.AppendLine(r.productName);
                        }
                        contentRow.Add(friday.ToString());

                        string[] contentRowStringArray = new string[contentRow.Count()];
                        contentRowStringArray = contentRow.ToArray();
                        content.Add(contentRowStringArray);
                    }
                    contents.Add(content);
                }

                

                var num = 6;
                foreach (var a in contents)
                {
                    //Tabla1
                    
                    ws.Cells["B"+num+":I"+num].StyleName = "styleHeader";
                    ws.Cells["B"+(num+1)+":I"+(num+a.Count()-1)].StyleName = "styleContent";
                    ws.Cells["B"+num].LoadFromArrays(a);
                    
                    num += (a.Count()+1);
                }

                byte[] b = p.GetAsByteArray();
                ms = new MemoryStream(b);

            }

            return ms;
            

        }
    }
    
}
