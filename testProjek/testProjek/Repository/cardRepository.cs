using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Model;

namespace testProjek.Repository
{
    public class cardRepository
    {
        databaseEntities1 db = databaseSingleton.getInstance();

        public List<Card> getcards()
        {
            return db.Cards.ToList();
        }

        public void deleteCard(int id)
        {
            Card card = db.Cards.Find(id);
            if(card == null)
            {
                return;
            }
            db.Cards.Remove(card);
            db.SaveChanges();
        }

        public Card getCard(int id)
        {
            return db.Cards.Find(id);
        }

        public void updateCard(int id, Card card)
        {
            Card old = db.Cards.Find(id);
            old.CardName =  card.CardName;
            old.CardType = card.CardType;
            old.CardDesc = card.CardDesc;
            old.CardPrice = card.CardPrice;
            old.isFoil = card.isFoil;
            db.SaveChanges();
        }
    }
}