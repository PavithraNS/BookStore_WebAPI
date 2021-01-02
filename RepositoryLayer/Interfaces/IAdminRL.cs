
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAdminRL
    {
        bool RegisterAdmin(AdminUserRegistration admin);

        //List<EmployeeModel> GetAllEmployee();

        AdminUserRegistration AdminLogin(AdminUserLogin login);
        //EmployeeModel EmployeeLogin(AdminLogin login);
    }
}
