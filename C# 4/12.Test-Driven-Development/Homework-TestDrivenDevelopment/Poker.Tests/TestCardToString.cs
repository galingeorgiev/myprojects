namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCardToString
    {
        [TestMethod]
        public void TestToStringSevenDiamands()
        {
            Card currentCard = new Card(CardFace.Seven, CardSuit.Diamonds);
            string currentCardString = currentCard.ToString();
            Assert.AreEqual("7♦", currentCardString);
        }

        [TestMethod]
        public void TestToStringAceClubs()
        {
            Card currentCard = new Card(CardFace.Ace, CardSuit.Clubs);
            string currentCardString = currentCard.ToString();
            Assert.AreEqual("A♣", currentCardString);
        }

        [TestMethod]
        public void TestToStringJackHearts()
        {
            Card currentCard = new Card(CardFace.Jack, CardSuit.Hearts);
            string currentCardString = currentCard.ToString();
            Assert.AreEqual("J♥", currentCardString);
        }

        [TestMethod]
        public void TestToStringTenSpades()
        {
            Card currentCard = new Card(CardFace.Ten, CardSuit.Spades);
            string currentCardString = currentCard.ToString();
            Assert.AreEqual("10♠", currentCardString);
        }
    }
}
