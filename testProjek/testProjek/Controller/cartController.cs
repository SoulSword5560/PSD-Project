using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.handler;
using testProjek.Model;

namespace testProjek.Controller
{
    public class cartController
    {
        cartHandler cartHandler = new cartHandler();
        databaseEntities1 db = new databaseEntities1();

        public void addNewCart(int cardId, string userName)
        {
            var userId = db.Users.FirstOrDefault(x => x.UserName == userName)?.UserID;
            cartHandler.createCart(cardId, Convert.ToInt32(userId), 1);
        }

        public void updateQuantity(int id, int quantity)
        {
            if (quantity < 0)
            {
                return;
            }
            cartHandler.updateQuantity(id, quantity);
        }
        public List<Cart> getCarts()
        {
            return cartHandler.getCart();
        }
        public void deleteCart(int id)
        {
            cartHandler.deleteCart(id);
        }
        public Cart getCartByID(int id)
        {
            return cartHandler.getCartByID(id);
        }
        public void deleteAllCart(int userId)
        {
            cartHandler.deleteAllCart(userId);
        }
    }
}