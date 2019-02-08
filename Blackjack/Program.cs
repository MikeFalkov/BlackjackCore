using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackjackCore
{

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
                Console.WriteLine("Total: {0}", userHand.Sum(c => c.Value));
                Console.ReadLine();

                dealerHand.Add(deck.Deal());
                dealerHand.Add(deck.Deal());

                Console.WriteLine("{0} of {1}", dealerHand[0].Face.ToString(), dealerHand[0].Suit.ToString());
                Console.WriteLine("{0} of {1}", dealerHand[1].Face.ToString(), dealerHand[1].Suit.ToString());
                //Console.WriteLine("[Hole Card]");
                Console.WriteLine("{0}", dealerHand[0].Value);
                Console.ReadLine();

                if (userHand.Sum(c => c.Value) == 21)
                {
                    Console.WriteLine("You are winner");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("Hit or Stay");
                if (Console.ReadKey(true).Key == ConsoleKey.H)
                {
                    userHand.Add(deck.Deal());
                    Console.WriteLine("{0} of {1}", userHand[userHand.Count - 1].Face.ToString(), userHand[userHand.Count - 1].Suit.ToString());
                    Console.WriteLine("Total: {0}", userHand.Sum(c => c.Value));
                    if (userHand.Sum(c => c.Value) > 21)
                    {
                        Console.Write("Busted!\n");
                        break;
                    }
                    else if (userHand.Sum(c => c.Value) == 21)
                    {
                        Console.WriteLine("You are winner");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0} of {1}", dealerHand[0].Face.ToString(), dealerHand[0].Suit.ToString());
                        Console.WriteLine("{0} of {1}", dealerHand[1].Face.ToString(), dealerHand[1].Suit.ToString());
                        Console.WriteLine("Total: {0}", dealerHand.Sum(c => c.Value));
                        while (dealerHand.Sum(c => c.Value) < 17)
                        {
                            dealerHand.Add(deck.Deal());
                            Console.WriteLine("{0} of {1}", dealerHand.Count, dealerHand[dealerHand.Count - 1].Face, dealerHand[dealerHand.Count - 1].Suit);
                        }
                        if (dealerHand.Sum(c => c.Value) > 21)
                        {
                            Console.WriteLine("You are winner");
                            Console.ReadLine();
                            break;
                        }
                        else if (userHand.Sum(c => c.Value) < dealerHand.Sum(c => c.Value))
                        {
                            Console.WriteLine("You are loser");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You are winner");
                            Console.ReadLine();
                            break;
                        }
                    }
                }

                else
                {

                }
            }
        }

        static void Play()
        {
            
        }
    }
}