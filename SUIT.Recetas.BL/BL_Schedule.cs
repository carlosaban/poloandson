using SUIT.Pago.BE;
using SUIT.Pago.BL;
using SUIT.Recetas.BE;
using SUIT.Recetas.DA;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Recetas.BL
{
    public class BL_Schedule
    {
        public MySQLDatabase _database;
        public string connectionString;

        public List<BE_Schedule> GetScheduleGeneral(BE_Schedule bE_Schedule)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Schedule(_database).GetScheduleGeneral(bE_Schedule);
        }

        public bool CreateSchedule(BE_Schedule bE_Schedule)
        {
            _database = new MySQLDatabase(connectionString);
            bool bOk = true;
            BL_Invoice blInvoice = new BL_Invoice();
            blInvoice.connectionString = connectionString;
            //blInvoice._database = _database;

           VE_Invoice invoice =  blInvoice.CreateInvoiceGeneral(bE_Schedule.Invoice);
            bOk = (invoice != null);

            if (exist(bE_Schedule))
            {
                bOk = bOk && new DA_Schedule(_database).UpdateSchedule(bE_Schedule);
            }
            else
            {

                bOk = bOk && new DA_Schedule(_database).CreateSchedule(bE_Schedule);

            }


            return bOk;


        }

        public bool UpdateSchedule(BE_Schedule bE_Schedule)
        {
            _database = new MySQLDatabase(connectionString);
            bool bOk = true;
            BL_Invoice blInvoice = new BL_Invoice();
            blInvoice._database = _database;
            VE_Invoice invoice = blInvoice.updateInvoiceGeneral(bE_Schedule.Invoice);
            bOk = bOk && (invoice != null);

            if ( exist(bE_Schedule))
            {
                bOk = bOk && new DA_Schedule(_database).UpdateSchedule(bE_Schedule);
            }
            else {

                bOk = bOk && new DA_Schedule(_database).CreateSchedule(bE_Schedule);

            }


            

            return bOk;



        }
        public bool exist(BE_Schedule bE_Schedule)
        {
            return (this.GetScheduleGeneral(bE_Schedule).Count==1);


        }
    }
}
