using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml.Linq;
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

        public void createCard(string name, decimal price, string type, string desc, int foil) 
        {
            
            Card card =  cardFactory.createCard(name, price, type, desc, foil);
            cardRepository.createCard(card);
        }



        public void updateCard(int id,string name,decimal price, string type, string desc,int foil)
        {
            Card card = cardFactory.createCard(name, price, type, desc, foil);
            cardRepository.updateCard(id, card);
        }
        

        public List<Card> getCardByName(string cardName)
        {
            return cardRepository.getCardByName(cardName);
        }
    }
}