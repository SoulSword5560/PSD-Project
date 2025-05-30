using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Model;

namespace testProjek.Factory
{
    public class cartFactory
    {
        public Cart createNewCart(int cardId, int userId, int quantity)
        {
            Cart cart = new Cart();
            cart.CardID = cardId;
            cart.UserID = userId;
            cart.Quantity = quantity;
            return cart;
        }
    }
}