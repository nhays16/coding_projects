using System.Collections.Generic;
using System.Linq;

namespace Deck_of_Cards{

    public class Card
    {
        public static string[] Suits = new string[] {"Diamonds","Hearts","Spades","Clubs"};
        public string Suit;


        public string StrValue
        {
            get{
                string cardString;
                if(Value == 1 || Value >10)
                    switch(Value){
                        case 11:
                            cardString = "Jack";
                            break;
                        case 12:
                            cardString = "Queen";
                            break;
                        case 13:
                            cardString = "King";
                            break;
                        default:
                            cardString = "Ace";
                            break;
                    }
                else
                    cardString =  Value.ToString();

                return $"{cardString} of {Suit}";
            }
        }


        public int Value;


        public Card(int suitIdx, int value){

            Suit = Suits[suitIdx];
            Value = value;
        }
    }
}


//Card class
// - stringVal for Ace, 2, 3, 4, etc
// - suit for Clubs, Spades, Hearts, Diamonds
// - val for 1-13

//Deck class
// - cards for list of Card objects
// - make sure has list of 52 unique cards as "cards" property
// - deal method that selects top card, removes it from list of cards & returns card
// - reset method that resets cards property to contain original 52 cards
// - shuffle method that randomly reorders deck's cards

//Player class
// - hand property that is list of type Card
// - draw method that draws a card, adds it to player's hand & returns card, will require reference to deck object
// - discard method that discards Card at specified index from player's hand & returns this Card or null if the index does not exist
