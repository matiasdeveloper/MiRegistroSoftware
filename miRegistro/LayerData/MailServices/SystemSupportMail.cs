using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerData.MailServices
{
    class SystemSupportMail : MasterMailServer
    {
        public SystemSupportMail() 
        {
            senderMail = "registrocalafatesc@gmail.com";
            password = "registro998P";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            intialaizeSmtpClient();
        }
    }
}
