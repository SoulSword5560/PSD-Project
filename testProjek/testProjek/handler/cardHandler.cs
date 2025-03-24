using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Factory;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.handler
{
    public class cardHandler
    {
        cardRepository cardRepository = new cardRepository();
        cardFactory cardFactory = new cardFactory();
        public List<Card> getCards()
        {
            return cardRepository.getcards();
        }

        public void deleteCard(int id) 
        {
            if(id == null)
            {
                return;
            }
            cardRepository.deleteCard(id);
        }

        public Card getCardByID(int id)
        {
            return cardRepository.getCard(id);
        }

        public Card createCard(string name, decimal price, string type, string desc, int foil) 
        {
            return cardFactory.createCard(name, price, type, desc, foil);
        }

        public void updateCard(int id, Card card)
        {
            cardRepository.updateCard(id, card);
        }
    }
}