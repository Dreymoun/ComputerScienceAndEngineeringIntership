using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Module14.Homework.CardGame
{
    public class Karta
    {
        public enum Suit { Hearts, Diamonds, Clubs, Spades }
        public enum Rank { Six = 6, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

        public Suit CardSuit { get; }
        public Rank CardRank { get; }

        public Karta(Suit suit, Rank rank)
        {
            CardSuit = suit;
            CardRank = rank;
        }

        public static bool operator >(Karta a, Karta b)
        {
            if (a.CardRank == Rank.Ace && b.CardRank == Rank.Six)
            {
                return false;
            }
            return a.CardRank > b.CardRank;
        }

        public static bool operator <(Karta a, Karta b)
        {
            return !(a > b);
        }
    }

    public class Player
    {
        public List<Karta> Cards { get; private set; }

        public Player()
        {
            Cards = new List<Karta>();
        }

        public void ShowCards()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine($"{card.CardRank} of {card.CardSuit}");
            }
        }
    }

    public class Game
    {
        private List<Player> players = new List<Player>();
        private List<Karta> deck = new List<Karta>();

        public Game(int playerCount)
        {
            if (playerCount < 2)
            {
                throw new ArgumentException("Must have at least 2 players");
            }

            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new Player());
            }

            foreach (Karta.Suit suit in Enum.GetValues(typeof(Karta.Suit)))
            {
                foreach (Karta.Rank rank in Enum.GetValues(typeof(Karta.Rank)))
                {
                    deck.Add(new Karta(suit, rank));
                }
            }
        }

        public void ShuffleDeck()
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public void DealCards()
        {
            int playerIndex = 0;
            foreach (var card in deck)
            {
                players[playerIndex].Cards.Add(card);
                playerIndex = (playerIndex + 1) % players.Count;
            }
        }

        public void PlayGame()
        {
            while (!IsGameOver())
            {
                PlayRound();
            }

            var winner = players.FirstOrDefault(p => p.Cards.Count == 36);
            Console.WriteLine("Game over. Winner: Player " + players.IndexOf(winner));
        }

        private void PlayRound()
        {
            var cardsOnTable = new List<Karta>();

            foreach (var player in players)
            {
                if (player.Cards.Count == 0) continue;

                Karta card = player.Cards.First();
                player.Cards.RemoveAt(0);
                cardsOnTable.Add(card);

                Console.WriteLine($"Player {players.IndexOf(player)} plays {card.CardRank} of {card.CardSuit}");
            }

            if (cardsOnTable.Count == 0) return;

            int winningPlayerIndex = DetermineWinner(cardsOnTable);
            players[winningPlayerIndex].Cards.AddRange(cardsOnTable);

            Console.WriteLine($"Player {winningPlayerIndex} wins this round and now has {players[winningPlayerIndex].Cards.Count} cards.");
        }

        private int DetermineWinner(List<Karta> cards)
        {
            int winnerIndex = 0;
            for (int i = 1; i < players.Count; i++)
            {
                if (cards[i] > cards[winnerIndex])
                {
                    winnerIndex = i;
                }
            }
            return winnerIndex;
        }

        private bool IsGameOver()
        {
            return players.Any(p => p.Cards.Count == 36);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(2);
            game.ShuffleDeck();
            game.DealCards();
            game.PlayGame();
        }
    }
}
