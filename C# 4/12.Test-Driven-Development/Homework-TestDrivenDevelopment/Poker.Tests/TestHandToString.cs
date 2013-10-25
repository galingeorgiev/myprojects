namespace Poker.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class TestHandToString
    {
        [TestMethod]
        public void TestToStringWithoutCards()
        {
            IList<ICard> hand = new List<ICard>();

            Hand currentHand = new Hand(hand);

            Assert.AreEqual(string.Empty, currentHand.ToString());
        }

        [TestMethod]
        public void TestToStringWithOneCard()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            Hand currentHand = new Hand(hand);

            Assert.AreEqual("10♠", currentHand.ToString());
        }

        [TestMethod]
        public void TestToStringWithFourCard()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs)
            };

            Hand currentHand = new Hand(hand);

            Assert.AreEqual("10♠ 6♥ J♦ 2♣", currentHand.ToString());
        }
    }
}