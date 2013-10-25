namespace Poker.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestIsFourOfAKind
    {
        [TestMethod]
        public void TestValidFourOfKind()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades)
            };
            Hand currentHand = new Hand(hand);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool isValidFourOfAKind = checker.IsFourOfAKind(currentHand);
            Assert.AreEqual(true, isValidFourOfAKind);
        }
    }
}
