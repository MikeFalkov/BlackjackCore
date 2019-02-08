using BlackjackCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Blackjack.Test
{
    public class DeckTest
    {
        [Theory(DisplayName ="When the deck is created it supposed to have correct number of cards")]
        [InlineData(1,52)]
        [InlineData(2,104)]
        [InlineData(3,156)]
        public void CorrectSizeTest(int size, int expectedSize)
        {
            Deck deck = new Deck(size,null);
            Assert.Equal(expectedSize, deck.Count);

        }
        [Theory(DisplayName = "When the card is dealt the size of the deck reduces by one")]
        [InlineData(1, 51)]
        [InlineData(2, 103)]
        public void DealTest(int size, int expectedSize)
        {
            Deck deck = new Deck(size, null);
            var card = deck.Deal();
            Assert.Equal(expectedSize, deck.Count);

        }

        [Theory(DisplayName = "The deck shoud have all expected cards")]
        [InlineData(1, Suit.Diamond, 13, Face.Eight, 4)]
        [InlineData(2, Suit.Diamond, 26, Face.King, 8)]

        public void ExpectedCardsTest(int size,Suit suit, int suits, Face face, int faces)
        {
            Deck deck = new Deck(size, null);
            List<Card> blah = new List<Card>();
            while (deck.Count > 0)
            {
                blah.Add(deck.Deal());
            }
            Assert.Equal(suits, blah.Count(c => c.Suit == suit));
            Assert.Equal(faces, blah.Count(c => c.Face == face));
        }

        [Theory(DisplayName = "Shuffling")]
        [InlineData(1)]
        public void ShuffleTest(int size)
        {
            IEnumerable<int> sequence = Enumerable.Range(1, 52).Reverse();
            var randomizer = new RandomSequenceMock();
            
            randomizer.Seed(sequence.ToArray());

            Deck deck = new Deck(size,randomizer);
            deck.Shuffle();
            List<Card> blah = new List<Card>();
            while (deck.Count > 0)
            {
                blah.Add(deck.Deal());
            }
            Assert.Equal(Suit.Heart, blah[0].Suit);
            Assert.Equal(Face.Ace, blah[0].Face);
            Assert.Equal(Suit.Heart, blah[1].Suit);
            Assert.Equal(Face.Two, blah[1].Face);
        }
    }

    public class RandomSequenceMock : IRandomSequence
    {
        private Stack<int> _sequence = new Stack<int>();

        public void Seed(int[] sequence)
        {
            sequence.ToList().ForEach(s=> _sequence.Push(s) );
        }
        public int Next()
        {
            return _sequence.Pop();
        }
    }
}
