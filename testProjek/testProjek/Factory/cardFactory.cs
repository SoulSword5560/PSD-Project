using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Model;

namespace testProjek.Factory
{
    public class cardFactory
    {
        public Card createCard(string name, decimal price, string type, string desc, int foil)
        {
            Card card = new Card();
            card.CardName = name;
            card.CardPrice = price;
            card.CardType = type;
            card.CardDesc = desc;
            card.isFoil = new byte[] { Convert.ToByte(foil) };
            return card;
        }
    }
}