namespace Poker.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestIsValidHand
    {
        [TestMethod]
        public void TestIsValidHand_WithNoCards()
        {
            Hand currentHand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            bool isValidHand = checker.IsValidHand(currentHand);
            Assert.AreEqual(false, isValidHand);
        }

        [TestMethod]
        public void TestIsValidHand_FourCards()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            Hand currentHand = new Hand(hand);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool isValidHand = checker.IsValidHand(currentHand);
            Assert.AreEqual(false, isValidHand);
        }

        [TestMethod]
        public void TestIsValidHand_SixCards()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds)
            };
            Hand currentHand = new Hand(hand);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool isValidHand = checker.IsValidHand(currentHand);
            Assert.AreEqual(false, isValidHand);
        }

        [TestMethod]
        public void TestIsValidHand_EqualCards()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };
            Hand currentHand = new Hand(hand);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool isValidHand = checker.IsValidHand(currentHand);
            Assert.AreEqual(false, isValidHand);
        }

        [TestMethod]
        public void TestIsValidHand_CorrectHand()
        {
            IList<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };
            Hand currentHand = new Hand(hand);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool isValidHand = checker.IsValidHand(currentHand);
            Assert.AreEqual(true, isValidHand);
        }
    }
}
