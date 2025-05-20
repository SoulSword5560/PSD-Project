using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using testProjek.handler;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.Controller
{
    public class cardController
    {
        cardHandler cardHandler = new cardHandler();
        public string cardValidation(string name, decimal price, string type, string desc, int foil)
        {
            if(!Regex.IsMatch(name, @"^[A-Za-z ]{5,50}$"))
            {
                return "name must be 5-50 ";
            }
            if(price< 10000)
            {
                return "price must be >= 10000";
            }
            if (!type.Equals("spell", StringComparison.OrdinalIgnoreCase) && !type.Equals("monster", StringComparison.OrdinalIgnoreCase) )
            {
                return "type must be spell or monster";
            }
            if(desc == "")
            {
                return "desc must be filled";
            }
            if(foil != 0 && foil != 1)
            {
                return "foil must be yes or no";
            }
            cardHandler.createCard(name, price, type, desc,foil);
            return "";
        }
        public string cardUpdateValidation(int id, string name, decimal price, string type, string desc, int foil)
        {
            if (id == 0)
            {
                return "id must be filled";
            }
            if (!Regex.IsMatch(name, @"^[A-Za-z ]{5,50}$"))
            {
                return "name must be 5-50 ";
            }
            if (price < 10000)
            {
                return "price must be >= 10000";
            }
            if (!type.Equals("spell", StringComparison.OrdinalIgnoreCase) && !type.Equals("monster", StringComparison.OrdinalIgnoreCase))
            {
                return "type must be spell or monster";
            }
            if (desc == "")
            {
                return "desc must be filled";
            }
            if (foil != 0 && foil != 1)
            {
                return "foil must be yes or no";
            }
            cardHandler.updateCard(id, name, price, type, desc, foil);
            return "";
        }
        public List<Card> getCardByName(string cardName)
        {
            return cardHandler.getCardByName(cardName);
        }
        public List<Card> getCards()
        {
            return cardHandler.getCards();
        }
        public void deleteCard(int id)
        {
            cardHandler.deleteCard(id);
        }
        public Card getCardByID(int id)
        {
            return cardHandler.getCardByID(id);
        }
    }
}