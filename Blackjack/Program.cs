using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }

    public enum Face
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public int Value { get; set; }
    }

    public class Hand
    {
        public List<Card> Cards { get; set; }
        public int Score()
        {

        }
    }

    public class Deck
    {
        //private Card[] cards;
        private Stack<Card> stack;
        public int Count { get { return stack.Count(); } }

        public Deck(int size)
        {
            

            List<Card> deck = new List<Card>();
            for(int pack = 0; pack < size; pack++)
                for (int suit = 0; suit < 4; suit++)
                    for (int face = 1; face < 14; face++)
                        deck.Add(new Card { Face = (Face)face, Suit = (Suit)suit, Value = (face <= 10) ? face:10 });
            //cards = deck.ToArray();
            stack = new Stack<Card>(deck);

        }

        public void Shuffle()
        {
            Random rnd = new Random();
            stack = new Stack<Card>(stack.ToArray().OrderBy(x => rnd.Next()));
        }

        public Card Deal()
        {
            return stack.Pop();
        }

    }

    class Program
    {
        static int chips;
        static Deck deck;
        static List<Card> userHand;
        static List<Card> dealerHand;

        static void Main(string[] args)
        {
            deck = new Deck(2);
            deck.Shuffle();

            while (deck.Count > 0)
            {
                var card = deck.Deal();

                Hand hand = new Hand();
                hand.Cards.Add(card);

                Console.WriteLine("{0} of {1}", card.Face.ToString(), card.Suit.ToString());
                Console.ReadLine();
            }
        }

        static void DealHand()
        {

        }
    }
}