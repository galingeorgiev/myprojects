namespace Poker.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestIsFlush
    {
        [TestMethod]
        public void TestIsNotStraightFlush()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };
            Hand currentHand = new Hand(hand);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool isValidFlush = checker.IsFlush(currentHand);
            Assert.AreEqual(false, isValidFlush);
        }

        [TestMethod]
        public void TestIsFlushCorrect()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades)
            };
            Hand currentHand = new Hand(hand);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool isValidFlush = checker.IsFlush(currentHand);
            Assert.AreEqual(true, isValidFlush);
        }
    }
}
