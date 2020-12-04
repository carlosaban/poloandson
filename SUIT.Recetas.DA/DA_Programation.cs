using SUIT.BE.n;
using SUIT.Recetas.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.DA
{
    public class DA_Programation
    {
        public MySQLDatabase _database { get; set; }

        public DA_Programation(MySQLDatabase database)
        {
            _database = database;
        }

        public List<BE_Programation> GetProgramationGeneral(int programationId, int month, int headquartersId,int dietId)
        {
            BE_Programation _bE_Programation = null;
            List<BE_Programation> _lstProgramation = new List<BE_Programation>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_programationId", (programationId == 0) ? DBNull.Value : (object)programationId);
            parameters.Add("_headquartersId", (headquartersId == 0) ? DBNull.Value : (object)headquartersId);
            parameters.Add("_dietId", (dietId == 0) ? DBNull.Value : (object)dietId);
            parameters.Add("_month", (month == 0) ? DBNull.Value : (object)month);

            var rows = _database.QuerySP("sp_getProgramationGeneral", parameters);
            foreach (var row in rows)
            {
                _bE_Programation = new BE_Programation();
                _bE_Programation.programationId = string.IsNullOrEmpty(row["programationId"]) ? 0 : int.Parse(row["programationId"]);
                _bE_Programation.date = string.IsNullOrEmpty(row["date"]) ? DateTime.Now : DateTime.Parse(row["date"]);
                _bE_Programation.dateFormat = _bE_Programation.date.ToShortDateString();
                _bE_Programation.costTotal = string.IsNullOrEmpty(row["costTotal"]) ? 0 : decimal.Parse(row["costTotal"]);
                _bE_Programation.feedingTimeId = string.IsNullOrEmpty(row["feedingTimeId"]) ? 0 : int.Parse(row["feedingTimeId"]);
                _bE_Programation.kcalTotal = string.IsNullOrEmpty(row["kcalTotal"]) ? 0 : int.Parse(row["kcalTotal"]);
                _bE_Programation.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                _lstProgramation.Add(_bE_Programation);
            }

            return _lstProgramation;
        }


        public List<VE_Programation> GetProgramationResumen(int year,  int month, int headquartersId, int dietId)
        {
            VE_Programation _vE_Programation = null;
            List<VE_Programation> _lstProgramation = new List<VE_Programation>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_headquartersId", (headquartersId == 0) ? DBNull.Value : (object)headquartersId);
            parameters.Add("_dietId", (dietId == 0) ? DBNull.Value : (object)dietId);
            parameters.Add("_month", (month == 0) ? DBNull.Value : (object)month);
            parameters.Add("_year", (month == 0) ? DBNull.Value : (object)year);

            util _util = new util();
            var rows = _database.QuerySP("sp_getProgramationResumen", parameters);
            foreach (var row in rows)
            {
                _vE_Programation = new VE_Programation();
                _vE_Programation.programationId = string.IsNullOrEmpty(row["programationId"]) ? 0 : int.Parse(row["programationId"]);
                _vE_Programation.date = string.IsNullOrEmpty(row["date"]) ? DateTime.Now : DateTime.Parse(row["date"]);
                _vE_Programation.dateFormat = _vE_Programation.date.ToString(util.CustomeDateFormat());
                _vE_Programation.dayOfWeek = _vE_Programation.date.DayOfWeek;
                _vE_Programation.dayOfMonth = _vE_Programation.date.Day;
                _vE_Programation.weekOfMonth = _util.GetWeekOfMonth(_vE_Programation.date).WeekOfMonth;
                _vE_Programation.costTotal = string.IsNullOrEmpty(row["costTotal"]) ? 0 : decimal.Parse(row["costTotal"]);
                _vE_Programation.feedingTimeId = string.IsNullOrEmpty(row["feedingTimeId"]) ? 0 : int.Parse(row["feedingTimeId"]);
                _vE_Programation.feedingTimeName = row["feedingTimeName"];
                _vE_Programation.kcalTotal = string.IsNullOrEmpty(row["kcalTotal"]) ? 0 : int.Parse(row["kcalTotal"]);
                _vE_Programation.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                _vE_Programation.productName = row["productName"];
                _vE_Programation.headquartersName = row["headquartersName"];
                _vE_Programation.dietName = row["dietName"];
                _vE_Programation.quantity = string.IsNullOrEmpty(row["quantity"]) ? 0 : decimal.Parse(row["quantity"]);
                _lstProgramation.Add(_vE_Programation);
            }

            return _lstProgramation;
        }

        public List<BEReportCategoryByProgramationView> GetCategoryByProgramation(int year, int month, int headquartersId, int dietId)
        {
            BEReportCategoryByProgramationView _vE_Programation = null;
            List<BEReportCategoryByProgramationView> _lstProgramation = new List<BEReportCategoryByProgramationView>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_headquartersId", (headquartersId == 0) ? DBNull.Value : (object)headquartersId);
            parameters.Add("_dietId", (dietId == 0) ? DBNull.Value : (object)dietId);
            parameters.Add("_month", (month == 0) ? DBNull.Value : (object)month);
            parameters.Add("_year", (month == 0) ? DBNull.Value : (object)year);

            util _util = new util();
            var rows = _database.QuerySP("receta_sp_GetCategoryByProgramation", parameters);
            foreach (var row in rows)
            {
                _vE_Programation = new BEReportCategoryByProgramationView();
                _vE_Programation.week = string.IsNullOrEmpty(row["week"]) ? 0 : int.Parse(row["week"]);
                _vE_Programation.strInitialDate = string.IsNullOrEmpty(row["strInitialDate"]) ? string.Empty: row["strInitialDate"];
                _vE_Programation.strFinalDate = string.IsNullOrEmpty(row["strFinalDate"]) ? string.Empty : row["strFinalDate"];
                _vE_Programation.categoryId = string.IsNullOrEmpty(row["categoryId"]) ? 0 : int.Parse(row["categoryId"]);
                _vE_Programation.category = string.IsNullOrEmpty(row["category"]) ? string.Empty : row["category"];

                _vE_Programation.subtotal = string.IsNullOrEmpty(row["subtotal"]) ? 0 : decimal.Parse(row["subtotal"]);
                _vE_Programation.percent = string.IsNullOrEmpty(row["percent"]) ? 0 : decimal.Parse(row["percent"]);

                _lstProgramation.Add(_vE_Programation);
            }

            return _lstProgramation;
        }

        public List<BEReportPodructCategoryByProgramationView> GetProductByCategoryByProgramation(int productCategoryId , int year, int month, int headquartersId, int dietId, int week)
        {
            BEReportPodructCategoryByProgramationView _vE_Programation = null;
            List<BEReportPodructCategoryByProgramationView> _lstProgramation = new List<BEReportPodructCategoryByProgramationView>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_productCategoryId", (productCategoryId == 0) ? DBNull.Value : (object)productCategoryId);

            parameters.Add("_headquartersId", (headquartersId == 0) ? DBNull.Value : (object)headquartersId);
            parameters.Add("_dietId", (dietId == 0) ? DBNull.Value : (object)dietId);
            parameters.Add("_month", (month == 0) ? DBNull.Value : (object)month);
            parameters.Add("_year", (year == 0) ? DBNull.Value : (object)year);
            parameters.Add("_week", (week == 0) ? DBNull.Value : (object)week);

            util _util = new util();
            var rows = _database.QuerySP("receta_sp_GetProductByCategoryByProgramation", parameters);
            foreach (var row in rows)
            {
                _vE_Programation = new BEReportPodructCategoryByProgramationView();
                _vE_Programation.week = string.IsNullOrEmpty(row["week"]) ? 0 : int.Parse(row["week"]);
                _vE_Programation.weekDay = string.IsNullOrEmpty(row["weekDay"]) ? 0 : int.Parse(row["weekDay"]);

                _vE_Programation.strInitialDate = string.IsNullOrEmpty(row["strInitialDate"]) ? string.Empty : row["strInitialDate"];
                _vE_Programation.strFinalDate = string.IsNullOrEmpty(row["strFinalDate"]) ? string.Empty : row["strFinalDate"];
                _vE_Programation.cost = string.IsNullOrEmpty(row["cost"]) ? 0 : decimal.Parse(row["cost"]);
                _vE_Programation.measure = string.IsNullOrEmpty(row["measure"]) ? string.Empty : row["measure"];
                _vE_Programation.productDate = string.IsNullOrEmpty(row["productDate"]) ? string.Empty : row["productDate"];
                _vE_Programation.productName = string.IsNullOrEmpty(row["productName"]) ? string.Empty : row["productName"];
                _vE_Programation.quantity = string.IsNullOrEmpty(row["quantity"]) ? 0 : decimal.Parse(row["quantity"]);
                _vE_Programation.InvoiceItemId = string.IsNullOrEmpty(row["InvoiceItemId"]) ? 0 : int.Parse(row["InvoiceItemId"]);
                _vE_Programation.Requested = string.IsNullOrEmpty(row["Requested"]) ? 0 : decimal.Parse(row["Requested"]);

                _lstProgramation.Add(_vE_Programation);
            }

            return _lstProgramation;
        }


        public List<VE_ProgramationDetail> GetProgramationDetailByProgramationId(int programationId)
        {
            VE_ProgramationDetail _vE_ProgramationDetail = null;
            List<VE_ProgramationDetail> _lstProgramationDetail = new List<VE_ProgramationDetail>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_programationId", (programationId == 0) ? DBNull.Value : (object)programationId);
            
            var rows = _database.QuerySP("sp_getProgramationDetailByProgramationId", parameters);
            foreach (var row in rows)
            {
                _vE_ProgramationDetail = new VE_ProgramationDetail();
                _vE_ProgramationDetail.programationId = string.IsNullOrEmpty(row["programationId"]) ? 0 : int.Parse(row["programationId"]);
                _vE_ProgramationDetail.productCost = string.IsNullOrEmpty(row["productCost"]) ? 0 : decimal.Parse(row["productCost"]);
                _vE_ProgramationDetail.productId = string.IsNullOrEmpty(row["productId"]) ? 0 : int.Parse(row["productId"]);
                _vE_ProgramationDetail.quantity = string.IsNullOrEmpty(row["quantity"]) ? 0 : decimal.Parse(row["quantity"]);
                _vE_ProgramationDetail.productKcal = string.IsNullOrEmpty(row["productKcal"]) ? 0 : int.Parse(row["productKcal"]);
                _vE_ProgramationDetail.productName = row["productName"];
                _lstProgramationDetail.Add(_vE_ProgramationDetail);
            }

            return _lstProgramationDetail;

        }

        public BE_Programation GetProgramationByDateAndFeedingTimeId(DateTime date, int feedingTimeId)
        {
            BE_Programation _bE_Programation = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_date", date);
            parameters.Add("_feedingTimeId", feedingTimeId);

            var rows = _database.QuerySP("sp_getProgramationByDateAndFeedingTimeId", parameters);
            foreach (var row in rows)
            {
                _bE_Programation = new BE_Programation();
                _bE_Programation.programationId = string.IsNullOrEmpty(row["programationId"]) ? 0 : int.Parse(row["programationId"]);
                _bE_Programation.date = string.IsNullOrEmpty(row["date"]) ? DateTime.Now : DateTime.Parse(row["date"]);
                _bE_Programation.dateFormat = _bE_Programation.date.ToShortDateString();
                _bE_Programation.costTotal = string.IsNullOrEmpty(row["costTotal"]) ? 0 : decimal.Parse(row["costTotal"]);
                _bE_Programation.feedingTimeId = string.IsNullOrEmpty(row["feedingTimeId"]) ? 0 : int.Parse(row["feedingTimeId"]);
                _bE_Programation.kcalTotal = string.IsNullOrEmpty(row["kcalTotal"]) ? 0 : int.Parse(row["kcalTotal"]);
                _bE_Programation.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
            }

            return _bE_Programation;
        }

        public List<VE_ProgramationDetail> GetProgramationDetailByDateAndFeedingTimeId(DateTime date,int feedingTimeId)
        {
            VE_ProgramationDetail _vE_ProgramationDetail = null;
            List<VE_ProgramationDetail> _lstProgramationDetail = new List<VE_ProgramationDetail>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_date", date);
            parameters.Add("_feedingTimeId", feedingTimeId);

            var rows = _database.QuerySP("sp_getProgramationDetailByDateAndFeedingTimeId", parameters);
            foreach (var row in rows)
            {
                _vE_ProgramationDetail = new VE_ProgramationDetail();
                _vE_ProgramationDetail.programationId = string.IsNullOrEmpty(row["programationId"]) ? 0 : int.Parse(row["programationId"]);
                _vE_ProgramationDetail.productCost = string.IsNullOrEmpty(row["productCost"]) ? 0 : decimal.Parse(row["productCost"]);
                _vE_ProgramationDetail.productId = string.IsNullOrEmpty(row["productId"]) ? 0 : int.Parse(row["productId"]);
                _vE_ProgramationDetail.quantity = string.IsNullOrEmpty(row["quantity"]) ? 0 : decimal.Parse(row["quantity"]);
                _vE_ProgramationDetail.productKcal = string.IsNullOrEmpty(row["productKcal"]) ? 0 : int.Parse(row["productKcal"]);
                _vE_ProgramationDetail.productName = row["productName"];
                _lstProgramationDetail.Add(_vE_ProgramationDetail);
            }

            return _lstProgramationDetail;
        }

        public BE_Programation CreateProgramation(BE_Programation bE_Programation)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_date", (bE_Programation.date == null) ? DBNull.Value : (object)bE_Programation.date);
            parameters.Add("_costTotal", bE_Programation.costTotal);
            parameters.Add("_feedingTimeId", bE_Programation.feedingTimeId);
            parameters.Add("_kcalTotal", (bE_Programation.kcalTotal == 0) ? DBNull.Value : (object)bE_Programation.kcalTotal);

            var programationId = _database.ExecuteSPGetId("sp_createProgramation", parameters);

            boResultado = (programationId != null);
            if (boResultado)
            {
                bE_Programation.programationId = int.Parse(programationId.ToString());
                return bE_Programation;
            }
            return null;
        }

        public BE_ProgramationDetail CreateProgramationDetail(BE_ProgramationDetail bE_ProgramationDetail)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_programationId", bE_ProgramationDetail.programationId);
            parameters.Add("_quantity", (bE_ProgramationDetail.quantity == 0) ? DBNull.Value : (object)bE_ProgramationDetail.quantity);
            parameters.Add("_productCost", (bE_ProgramationDetail.productCost == 0) ? DBNull.Value : (object)bE_ProgramationDetail.productCost);
            parameters.Add("_productId", bE_ProgramationDetail.productId);
            parameters.Add("_productKcal", (bE_ProgramationDetail.productKcal == 0) ? DBNull.Value : (object)bE_ProgramationDetail.productKcal);

            var programationDetailId = _database.ExecuteSPGetId("sp_createProgramationDetail", parameters);

            boResultado = (programationDetailId != null);
            if (boResultado)
            {
                return bE_ProgramationDetail;
            }
            return null;

        }

        public BE_Programation UpdateProgramation(BE_Programation bE_Programation)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_programationId", (bE_Programation.programationId == 0) ? DBNull.Value : (object)bE_Programation.programationId);
            parameters.Add("_date", bE_Programation.date);
            parameters.Add("_costTotal", bE_Programation.costTotal);
            parameters.Add("_feedingTimeId", bE_Programation.feedingTimeId);
            parameters.Add("_kcalTotal", (bE_Programation.kcalTotal == 0) ? DBNull.Value : (object)bE_Programation.kcalTotal);

            filasAfectadas = _database.ExecuteSP("sp_updateProgramation", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_Programation;

            }
            return null;

        }


        public int DeleteProgramationDetailByProgramationId(int programationId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_programationId", (programationId == 0) ? DBNull.Value : (object)programationId);

            filasAfectadas = _database.ExecuteSP("sp_deleteProgramationDetailByProgramationId", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return filasAfectadas;
            }
            return 0;
        }






        public List<VE_ProgramationDetail> GetProgramationDetailResumen(int year ,int month, int headquartersId, int dietId)
        {
            VE_ProgramationDetail _vE_ProgramationDetail = null;
            List<VE_ProgramationDetail> _lstProgramationDetail = new List<VE_ProgramationDetail>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_headquartersId", (headquartersId == 0) ? DBNull.Value : (object)headquartersId);
            parameters.Add("_dietId", (dietId == 0) ? DBNull.Value : (object)dietId);
            parameters.Add("_month", (month == 0) ? DBNull.Value : (object)month);
            parameters.Add("_year", (year == 0) ? DBNull.Value : (object)year);

            util _util = new util();
            var rows = _database.QuerySP("sp_getProgramationDetailResumen", parameters);
            foreach (var row in rows)
            {
                _vE_ProgramationDetail = new VE_ProgramationDetail();
                _vE_ProgramationDetail.programationId = string.IsNullOrEmpty(row["programationId"]) ? 0 : int.Parse(row["programationId"]);
                _vE_ProgramationDetail.date = string.IsNullOrEmpty(row["date"]) ? DateTime.Now : DateTime.Parse(row["date"]);
                _vE_ProgramationDetail.dateFormat = _vE_ProgramationDetail.date.ToShortDateString();
                _vE_ProgramationDetail.dayOfWeek = _vE_ProgramationDetail.date.DayOfWeek;
                _vE_ProgramationDetail.dayOfMonth = _vE_ProgramationDetail.date.Day;
                _vE_ProgramationDetail.weekOfMonth = _util.GetWeekOfMonth(_vE_ProgramationDetail.date).WeekOfMonth;
                _vE_ProgramationDetail.productCost = string.IsNullOrEmpty(row["productCost"]) ? 0 : decimal.Parse(row["productCost"]);
                _vE_ProgramationDetail.productId = string.IsNullOrEmpty(row["productId"]) ? 0 : int.Parse(row["productId"]);
                _vE_ProgramationDetail.productKcal = string.IsNullOrEmpty(row["productKcal"]) ? 0 : int.Parse(row["productKcal"]);
                _vE_ProgramationDetail.productCategoryId = string.IsNullOrEmpty(row["productCategoryId"]) ? 0 : int.Parse(row["productCategoryId"]);
                _vE_ProgramationDetail.productCategoryName = row["productCategoryName"];
                _vE_ProgramationDetail.productName = row["productName"];
                _vE_ProgramationDetail.headquartersName = row["headquartersName"];
                _vE_ProgramationDetail.dietName = row["dietName"];

                _vE_ProgramationDetail.quantity = string.IsNullOrEmpty(row["quantity"]) ? 0 : decimal.Parse(row["quantity"]);
                _lstProgramationDetail.Add(_vE_ProgramationDetail);
            }

            return _lstProgramationDetail;
        }

    }
}
