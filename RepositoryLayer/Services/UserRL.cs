
using CommonLayer.Models;
using Repository;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly BookStoreContext context;

        public UserRL(BookStoreContext context)
        {
            this.context = context;
        }

        public bool RegisterUser(UserRegistration o)
        {
            try
            {
                UserRegistration existUser = this.context.userRegistrations.Where(x => x.email == o.email).FirstOrDefault();
                if (existUser == null)
                {
                    UserRegistration employeeObject = new UserRegistration()
                    {
                        fullName = o.fullName,
                        email = o.email,
                        password = o.password,
                        phone = o.phone,

                        createdAt = o.createdAt,
                        // Role = o.Role,
                        updatedAt = o.updatedAt
                    };

                    this.context.userRegistrations.Add(employeeObject);
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
                else
                {
                    throw new Exception("Email already Exist");
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public UserRegistration UserLogin(UserLogin login)
        {
            try
            {
                return this.context.userRegistrations.Where(x =>
                                                 x.email == login.email && x.password == login.password
                                                )
                                    .Select(o => new UserRegistration
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


    }
}
