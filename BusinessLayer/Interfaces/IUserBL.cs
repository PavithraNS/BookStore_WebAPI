using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        bool RegisterUser(UserRegistration admin);

        //List<AdminUserRegistration> GetAllEmployee();

        UserRegistration UserLogin(UserLogin login);
    }
}
