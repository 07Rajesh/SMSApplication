using SMSAPI.DBAccess;
using SMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessAccessLayer.BlAdmin
{
  public  class BlAdmin
    {
        AdminDbAccess adminDb = new AdminDbAccess();

        public string LoginAdmin(AdminLogin admin)
        {
            return adminDb.LoginAdmin(admin);
        }
    }
}
