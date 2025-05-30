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

        public void updateCart()
        {

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
    }
}