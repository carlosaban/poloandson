using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.Security.BE;
namespace SUIT.Security.BE
{
    public class VE_User : BE_User
    {
        public string companyName { get; set; }
        public string companyDocumento { get; set; }
        public string companyCode { get; set; }
        public string rolaName { get; set; }
        public string roleId { get; set; }
        public string userAudit { get; set; }
        public string quantityAuth { get; set; }

        public List<BE_Option> Options { get; set; }

        public VE_User()
        {
            Options = new List<BE_Option>();


        }

    }
}
