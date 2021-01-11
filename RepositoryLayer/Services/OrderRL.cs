using CommonLayer.Models;
using Repository;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RepositoryLayer.Services
{
    public class OrderRL: IOrderRL
    {
        private readonly BookStoreContext context;

        public OrderRL(BookStoreContext context)
        {
            this.context = context;
        }
        public NewOrder PlaceOrder(string LoggedInUser)
        {
            try
            {
                List<CartItem> list = (from e in this.context.cartItems
                                        select new CartItem
                                         {
                                              product_id = e.product_id,
                                              quantityToBuy = e.quantityToBuy,
                                               Product=e.Product,
                                              loginUser = e.loginUser
                                         }).Where(x => x.loginUser == LoggedInUser).ToList<CartItem>();
                CustomerDetails customer = this.context.customerDetails.Find(x=>x.email==LoggedInUser).FirstOrDefault();
                
                NewOrder newOrder = new NewOrder();
                newOrder.orders = list;
                newOrder.customer = customer;
                newOrder.customer.CustomerId = customer.CustomerId;
                this.context.Add(newOrder);
               int result=this.context.SaveChanges();
                if (newOrder.orders != null && result>0)
                {
                    return newOrder;
                }
                else
                {
                    throw new Exception("Order not placed succesfully");
                }
            }          
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
