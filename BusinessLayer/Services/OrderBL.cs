using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrderBL:IOrderBL
    {       
        private readonly IOrderRL orderRL;

        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public NewOrder PlaceOrder(string LoggedInUser)
        {
            try
            {
                //string LoggedInUser = HttpContext.Session.GetString("LogedInUser");
                return this.orderRL.PlaceOrder(LoggedInUser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
