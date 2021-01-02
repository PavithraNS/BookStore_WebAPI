
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        bool RegisterUser(UserRegistration employee);

        //bool Delete(int EmpId);
        UserRegistration UserLogin(UserLogin login);
        //bool EditEmployee(UpdateModel updatedEmployee, int EmpId);

        //List<CompanyEmployee> GetAllEmployee();
    }
}
