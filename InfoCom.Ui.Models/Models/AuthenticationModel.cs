using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCom.Ui.Models.Models
{
    public class AuthenticationModel
    {

        public bool IsActivate { get; set; }

        public string Token { get; set; }

        public DateTime TokenExpireDate { get; set; }
    }
}
