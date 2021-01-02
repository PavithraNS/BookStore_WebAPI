
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICartBL
    {
        bool AddCart(CartItem productId);
        bool UpdateCart(CartItem productId);

        List<Product> GetCartItems(string LoggedInUser);
        bool RemoveCartItem(CartItem productId);
        bool ReduceBookQuantity(CartItem productId);

        //AdminUserRegistration AdminLogin(AdminUserLogin login);
    }
}
