using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackjackCore
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

    public class Deck
    {
        //private Card[] cards;
        private Stack<Card> stack;
        public int Count { get { return stack.Count(); } }

        public Deck(int size)
        {


            List<Card> deck = new List<Card>();
            for (int pack = 0; pack < size; pack++)
                for (int suit = 0; suit < 4; suit++)
                    for (int face = 1; face < 14; face++)
                        deck.Add(new Card { Face = (Face)face, Suit = (Suit)suit, Value = (face <= 10) ? face : 10 });
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
            userHand = new List<Card>();
            dealerHand = new List<Card>();
            deck.Shuffle();

            while (deck.Count > 0)
            {
                userHand.Add(deck.Deal());
                userHand.Add(deck.Deal());

                Console.WriteLine("{0} of {1}", userHand[0].Face.ToString(), userHand[0].Suit.ToString());
                Console.WriteLine("{0} of {1}", userHand[1].Face.ToString(), userHand[1].Suit.ToString());
                Console.ReadLine();

                dealerHand.Add(deck.Deal());
                dealerHand.Add(deck.Deal());

                Console.WriteLine("{0} of {1}", dealerHand[0].Face.ToString(), dealerHand[0].Suit.ToString());
                Console.WriteLine("{0} of {1}", dealerHand[1].Face.ToString(), dealerHand[1].Suit.ToString());
                Console.ReadLine();



            }
        }

        static void DealHand()
        {

        }
    }
}