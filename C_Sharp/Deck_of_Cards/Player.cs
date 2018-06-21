using System.Collections.Generic;
using System.Linq;

namespace Deck_of_Cards{

    public class Player
    {

        public List<Card> Hand = new List<Card>();

        public void Draw(Deck deck){
            Hand.Add(deck.Deal());
        }

        public Card Discard(int idx){
            Card toDiscard = Hand[idx];
            Hand.RemoveAt(idx);
            return toDiscard;
        }
    }
}

//Player class
// - hand property that is list of type Card
// - draw method that draws a card, adds it to player's hand & returns card, will require reference to deck object
// - discard method that discards Card at specified index from player's hand & returns this Card or null if the index does not exist
