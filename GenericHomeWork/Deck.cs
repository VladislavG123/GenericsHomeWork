using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHomeWork
{
    public class Deck
    {
        public List<Card> Cards = new List<Card>();
        public const int AMOUNT_SUITS = 4;
        public const int AMOUNT_CARDS = 36;

        public Deck()
        {
            InitDeck();
        }

        public void InitDeck()
        {
            for (int cardTypeId = 0; cardTypeId < AMOUNT_CARDS / AMOUNT_SUITS; cardTypeId++)
            {
                for (int suitId = 0; suitId < AMOUNT_SUITS; suitId++)
                {
                    Cards.Add(new Card
                    {
                        CardType = (CardType)(cardTypeId),
                        Suit = (Suit)(suitId)
                    });
                }
            }
        }
    }
}
