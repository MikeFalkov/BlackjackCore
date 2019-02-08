using System.Collections.Generic;
using System.Linq;

namespace BlackjackCore
{
    public class Deck
    {
        //private Card[] cards;
        private Stack<Card> stack;
        private readonly IRandomSequence _rnd;

        public int Count { get { return stack.Count(); } }

        public Deck(int size, IRandomSequence randomSequence)
        {
            List<Card> deck = new List<Card>();
            for (int pack = 0; pack < size; pack++)
                for (int suit = 0; suit < 4; suit++)
                    for (int face = 1; face < 14; face++)
                        deck.Add(new Card { Face = (Face)face, Suit = (Suit)suit, Value = (face <= 10) ? face : 10 });
            //cards = deck.ToArray();
            stack = new Stack<Card>(deck);
            this._rnd = randomSequence;
        }

        public void Shuffle()
        {
            stack = new Stack<Card>(stack.ToArray().OrderBy(x => _rnd.Next()));
        }

        public Card Deal()
        {
            return stack.Pop();
        }

    }
}