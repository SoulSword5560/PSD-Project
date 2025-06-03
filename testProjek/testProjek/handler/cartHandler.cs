using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Factory;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.handler
{
    public class cartHandler
    {
        cartFactory cartFactory = new cartFactory();
        cartRepository cartRepository = new cartRepository();

        public List<Cart> getCart()
        {
            return cartRepository.getcarts();
        }

        public void deleteCart(int id)
        {
            if (id == 0)
            {
                return;
            }
            cartRepository.deleteCart(id);
        }

        public void deleteAllCart(int userId)
        {
            if (userId == 0)
            {
                return;
            }
            cartRepository.deleteAllCart(userId);
        }

        public Cart getCartByID(int id)
        {
            return cartRepository.getCart(id);
        }

        public void createCart(int cardId, int userId, int quantity)
        {

            Cart cart = cartFactory.createNewCart(cardId, userId, quantity);
            cartRepository.createCart(cart);
        }

        public void updateQuantity(int id, int quantity)
        {
            Cart cart = cartRepository.getCart(id);
            if (cart == null)
            {
                return;
            }
            if (id == cart.CartID)
            {
                cartRepository.updateQuantity(cart.CartID, quantity);
            }
        }
    }
}