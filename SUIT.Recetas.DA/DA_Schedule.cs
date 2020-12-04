using SUIT.Pago.DA;
using SUIT.Recetas.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.DA
{
    public class DA_Schedule
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MySQLDatabase _database { get; set; }

        public DA_Schedule(MySQLDatabase database)
        {
            _database = database;
        }

        public List<BE_Schedule> GetScheduleGeneral(BE_Schedule bE_Schedule)
        {
            try
            {
                BE_Schedule _bE_Schedule = null;
                List<BE_Schedule> _lstSchedule = new List<BE_Schedule>();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("_InvoiceId", (string.IsNullOrWhiteSpace(bE_Schedule.Invoice.invoiceId)) ? DBNull.Value : (object)bE_Schedule.Invoice.invoiceId);

                // parameters.Add("_StartDate", bE_Schedule.StartDate);
                //parameters.Add("_EndDate", bE_Schedule.EndDate);
                //parameters.Add("_Delivery", bE_Schedule.Delivery);
                //parameters.Add("_PaymentMethod", (bE_Schedule.PaymentMethod == 0) ? DBNull.Value : (object)bE_Schedule.PaymentMethod);
                DA_Invoice InvoiceDA = new DA_Invoice(this._database);


                var rows = _database.QuerySP("sp_getScheduleGeneral", parameters);
                foreach (var row in rows)
                {
                    BE_Schedule _temp = new BE_Schedule();
                    // _temp.Invoice = InvoiceDA.getInvoiceGeneral(new Pago.BE.n.Filters.BEInvoiceFilter() { invoiceId = bE_Schedule.Invoice.invoiceId })[0]; //InvoiceDA.getInvoiceGeneral(new Pago.BE.n.Filters.BEInvoiceFilter() { invoiceId = (bE_Schedule.Invoice.invoiceId)  });


                    _temp.StartDate = (row["StartDate"] == null) ? null : _bE_Schedule.StartDate;
                    _temp.StartDate = (row["StartDate"] == null) ? null : _bE_Schedule.StartDate;
                    _temp.EndDate = (row["EndDate"] == null) ? null : _bE_Schedule.EndDate;
                    _temp.Delivery = (row["Delivery"] == null) ? null : _bE_Schedule.Delivery;
                    _temp.PaymentMethod = (row["PaymentMethod"] == null) ? 0 : int.Parse(row["PaymentMethod"].ToString());

                    _lstSchedule.Add(_temp);
                }

                return _lstSchedule;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

   
        public bool CreateSchedule(BE_Schedule bE_Schedule)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            try
            {
                logger.Debug("In CreateSchedule(bE_Schedule) ");
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("_InvoiceId", (string.IsNullOrWhiteSpace(bE_Schedule.Invoice.invoiceId)) ? DBNull.Value : (object)bE_Schedule.Invoice.invoiceId);
                parameters.Add("_StartDate", bE_Schedule.StartDate);
                parameters.Add("_EndDate", bE_Schedule.EndDate);
                parameters.Add("_Delivery", bE_Schedule.Delivery);
                parameters.Add("_PaymentMethod", (bE_Schedule.PaymentMethod == 0) ? DBNull.Value : (object)bE_Schedule.PaymentMethod);

                int rowAffected = _database.ExecuteSP("sp_createSchedule", parameters);

                boResultado = (rowAffected != 0);
               
                return boResultado;


            }
            catch (Exception ex)
            {
                logger.Fatal(ex,"CreateSchedule(bE_Schedule) Exception: " + ex.Message);
                throw ex;
            }
            

        }

 
        public bool UpdateSchedule(BE_Schedule bE_Schedule)
        {
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            try
            {
                logger.Debug("In CreateSchedule(bE_Schedule) ");
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("_InvoiceId", (string.IsNullOrWhiteSpace(bE_Schedule.Invoice.invoiceId)) ? DBNull.Value : (object)bE_Schedule.Invoice.invoiceId);
                parameters.Add("_StartDate", bE_Schedule.StartDate);
                parameters.Add("_EndDate", bE_Schedule.EndDate);
                parameters.Add("_Delivery", bE_Schedule.Delivery);
                parameters.Add("_PaymentMethod", (bE_Schedule.PaymentMethod == 0) ? DBNull.Value : (object)bE_Schedule.PaymentMethod);

                var scheduleId = _database.ExecuteSPGetId("sp_UpdateSchedule", parameters);

                boResultado = (scheduleId != null);

                return boResultado;


            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "UpdateSchedule Exception: " + ex.Message);
                throw ex;
            }

        }

      

     
    }
}
