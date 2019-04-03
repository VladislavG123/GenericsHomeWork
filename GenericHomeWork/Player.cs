using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHomeWork
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>(); 

        public Card GetCard()
        {
            Card card = Cards[0];
            for (int i = 0; i < Cards.Count - 1; i++)
            {
                Cards[i] = Cards[i + 1];
            }
            Cards.Remove(Cards[Cards.Count - 1]);
            return card;
        }
    }
}
