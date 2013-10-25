namespace Poker
{
    using System;
    using System.Text;

    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public static bool operator ==(Card firstCard, Card secondCard)
        {
            bool isEqual = (firstCard.Face == secondCard.Face) && (firstCard.Suit == secondCard.Suit);
            return isEqual;
        }

        public static bool operator !=(Card firstCard, Card secondCard)
        {
            bool isEqual = !(firstCard == secondCard);
            return isEqual;
        }

        public override string ToString()
        {
            StringBuilder card = new StringBuilder();

            switch (this.Face)
            {
                case CardFace.Two:
                    card.Append("2");
                    break;
                case CardFace.Three:
                    card.Append("3");
                    break;
                case CardFace.Four:
                    card.Append("4");
                    break;
                case CardFace.Five:
                    card.Append("5");
                    break;
                case CardFace.Six:
                    card.Append("6");
                    break;
                case CardFace.Seven:
                    card.Append("7");
                    break;
                case CardFace.Eight:
                    card.Append("8");
                    break;
                case CardFace.Nine:
                    card.Append("9");
                    break;
                case CardFace.Ten:
                    card.Append("10");
                    break;
                case CardFace.Jack:
                    card.Append("J");
                    break;
                case CardFace.Queen:
                    card.Append("Q");
                    break;
                case CardFace.King:
                    card.Append("K");
                    break;
                case CardFace.Ace:
                    card.Append("A");
                    break;
                default:
                    throw new ArgumentException("Incorrect card face.");
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    card.Append("♣");
                    break;
                case CardSuit.Diamonds:
                    card.Append("♦");
                    break;
                case CardSuit.Hearts:
                    card.Append("♥");
                    break;
                case CardSuit.Spades:
                    card.Append("♠");
                    break;
                default:
                    throw new ArgumentException("Incorrect card suit.");
            }

            return card.ToString();
        }
    }
}