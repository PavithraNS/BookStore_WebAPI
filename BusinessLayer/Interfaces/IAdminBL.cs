
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAdminBL
    {
        bool RegisterAdmin(AdminUserRegistration admin);

        //List<AdminUserRegistration> GetAllEmployee();

        AdminUserRegistration AdminLogin(AdminUserLogin login);
    }
}
