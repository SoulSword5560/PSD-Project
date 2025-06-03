using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Model;

namespace testProjek.Repository
{
    public class cartRepository
    {
        databaseEntities1 db = databaseSingleton.getInstance();

        public List<Cart> getcarts()
        {
            return db.Carts.ToList();
        }

        public void deleteCart(int id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return;
            }
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public void deleteAllCart(int userId)
        {
            var carts = db.Carts.Where(c => c.UserID == userId).ToList();

            foreach (var cart in carts)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
        }
        public Cart getCart(int id)
        {
            return db.Carts.Find(id);
        }

        public void createCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public void updateQuantity(int id, int quantity)
        {
            Cart old = db.Carts.Find(id);
            old.Quantity = quantity;
            db.SaveChanges();
        }
    }
}