namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            if (this.HasEqualCards(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            bool isFourOfAKind = false;
            int counterEqualCards = 1;
            Hand sortedHand = SortHand(hand);

            for (int i = 0; i < sortedHand.Cards.Count - 1; i++)
            {
                if (sortedHand.Cards[i].Face == sortedHand.Cards[i + 1].Face)
                {
                    counterEqualCards++;
                }
            }

            if (counterEqualCards == 4)
            {
                isFourOfAKind = true;
            }

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            bool isFlush = true;
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i].Suit != hand.Cards[i + 1].Suit)
                {
                    isFlush = false;
                    break;
                }
            }

            if (isFlush && this.IsStraight(hand))
            {
                isFlush = false;
            }

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            Hand sortedHand = SortHand(hand);
            bool isStraight = true;
            for (int i = 0; i < sortedHand.Cards.Count - 1; i++)
            {
                if ((int)sortedHand.Cards[i].Face + 1 != (int)sortedHand.Cards[i + 1].Face)
                {
                    isStraight = false;
                    break;
                }
            }

            // Check for 2, 3, 4, 5, A
            if (sortedHand.Cards[0].Face == CardFace.Two && 
                sortedHand.Cards[1].Face == CardFace.Three &&
                sortedHand.Cards[2].Face == CardFace.Four &&
                sortedHand.Cards[3].Face == CardFace.Five &&
                sortedHand.Cards[4].Face == CardFace.Ace)
            {
                isStraight = true;
            }

            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private static Hand SortHand(IHand unsortedHand)
        {
            IList<ICard> hand = new List<ICard>();
            for (int i = 0; i < unsortedHand.Cards.Count - 1; i++)
            {
                ICard currentCard = unsortedHand.Cards[i];
                for (int j = i + 1; j < unsortedHand.Cards.Count; j++)
                {
                    if ((int)unsortedHand.Cards[j].Face < (int)currentCard.Face)
                    {
                        ICard oldCardValue = currentCard;
                        currentCard = unsortedHand.Cards[j];
                        unsortedHand.Cards[j] = oldCardValue;
                    }
                }

                hand.Add(currentCard);
            }
            hand.Add(unsortedHand.Cards[unsortedHand.Cards.Count - 1]);
            Hand sortedHand = new Hand(hand);
            return sortedHand;
        }

        private bool HasEqualCards(IHand hand)
        {
            bool hasEqualCards = false;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if ((Card)hand.Cards[i] == (Card)hand.Cards[j])
                    {
                        hasEqualCards = true;
                        break;
                    }
                }

                if (hasEqualCards)
                {
                    break;
                }
            }

            return hasEqualCards;
        }
    }
}
