
using CommonLayer.Models;
using Repository;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AdminRL : IAdminRL
    {
        private readonly BookStoreContext context;

        public AdminRL(BookStoreContext context)
        {
            this.context = context;
        }

        public AdminUserRegistration AdminLogin(AdminUserLogin login)
        {
            try
            {
                return this.context.adminUserRegistrations.Where(x =>
                                                 x.email == login.email && x.password == login.password
                                                )
                                    .Select(o => new AdminUserRegistration
                                    {
                                        fullName = o.fullName,
                                        email = o.email,
                                        password = o.password,
                                        phone = o.phone,

                                        createdAt = o.createdAt,
                                       // Role = o.Role,
                                        updatedAt = o.updatedAt
                                    }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       

        public bool RegisterAdmin(AdminUserRegistration o)
        {
            try
            {
                AdminUserRegistration adminObject = new AdminUserRegistration()
                {
                    fullName = o.fullName,
                    email = o.email,
                    password = o.password,
                    phone = o.phone,

                    createdAt = o.createdAt,
                    // Role = o.Role,
                    updatedAt = o.updatedAt
                };

                this.context.adminUserRegistrations.Add(adminObject);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
