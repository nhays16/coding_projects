using System;
using System.Collections.Generic;
using System.Linq;

namespace Deck_of_Cards{

    public class Deck{
        
        public List<Card> Cards;

        public Deck(){
            Cards = new List<Card>();

            for(int suit = 0; suit < 4; suit++)
            {
                for(int v = 1; v < 14; v++)
                {
                    Cards.Add(new Card(suit,v));
                }
            }
        }

        public Card Deal(){

            Card toDeal = Cards[0];
            Cards.RemoveAt(0);
            return toDeal;
        }

        public Deck Shuffle(){
            Random rand = new Random();
            int i = 0;
            int randCardIdx = rand.Next(i, Cards.Count);

        }

        public Deck Reset(){
            Cards = new List<Card>();
            string[] suits = {"Hearts","Spades","Diamonds","Clubs"};
            foreach(string suit in suits){
                for(int val=1;val<=13;val++){
                    Cards.Add(new Card(suit, val));
                }
            }
            return this;
        }

    }
}



//Deck class
// - cards for list of Card objects
// - make sure has list of 52 unique cards as "cards" property
// - deal method that selects top card, removes it from list of cards & returns card
// - reset method that resets cards property to contain original 52 cards
// - shuffle method that randomly reorders deck's cards