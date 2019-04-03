using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHomeWork
{
    public class Game
    {
        public Deck Deck { get; set; } = new Deck();
        List<Player> Players { get; set; } = new List<Player>();
        public const int MAX_AMOUNT_PLAYERS = 6;
        public const int MIN_AMOUNT_PLAYERS = 2;
        public int AmountPlayers { get; private set; }

        public Game(List<Player> players)
        {
            AmountPlayers = players.Count;
            for (int i = 0; i < AmountPlayers; i++)
                Players.Add(players[i]);
            if (AmountPlayers < MIN_AMOUNT_PLAYERS || AmountPlayers > MAX_AMOUNT_PLAYERS)
                throw new Exception("Некорректное количество игроков!");
            else
            {
                for (int i = 0, playerId = 0; i <= Deck.AMOUNT_CARDS; i++, playerId++)
                {
                    if (i >= Deck.AMOUNT_CARDS)
                        break;
                    for (int j = 0; j < Deck.AMOUNT_CARDS / AmountPlayers; j++)
                    {
                        Players[playerId].Cards.Add(Deck.Cards[j+i]);
                    }
                    i += Deck.AMOUNT_CARDS / AmountPlayers - 1;
                    
                }
            }
        }

        public Player Start()
        {
            int firstPlayerId = 0;
            int secondPlayerId = 1;
            while (true)
            {
                foreach (var player in Players)
                {
                    if (player.Cards.Count == Deck.AMOUNT_CARDS)
                    {
                        return player;
                    }
                }

                var firstPlayersCard = Players[firstPlayerId].GetCard();
                var secondPlayersCard = Players[secondPlayerId].GetCard();
                Console.WriteLine($"{Players[firstPlayerId].Name} - {firstPlayersCard.CardType.ToString()}");
                Console.WriteLine($"{Players[secondPlayerId].Name} - {secondPlayersCard.CardType.ToString()}");
                
                if ((int)(firstPlayersCard.CardType) >= (int)(secondPlayersCard.CardType))
                {
                    Console.WriteLine($"{Players[firstPlayerId].Name} забрал(a) карты");
                    Players[firstPlayerId].Cards.Add(firstPlayersCard);
                    Players[firstPlayerId].Cards.Add(secondPlayersCard);
                }
                else
                {
                    Console.WriteLine($"{Players[secondPlayerId].Name} забрал(a) карты");
                    Players[secondPlayerId].Cards.Add(firstPlayersCard);
                    Players[secondPlayerId].Cards.Add(secondPlayersCard);
                }
                Console.WriteLine();

                firstPlayerId++;
                secondPlayerId++;
                if (AmountPlayers <= firstPlayerId)
                    firstPlayerId = 0;
                if (AmountPlayers <= secondPlayerId)
                    secondPlayerId = 0;
            }
        }

    }
}
