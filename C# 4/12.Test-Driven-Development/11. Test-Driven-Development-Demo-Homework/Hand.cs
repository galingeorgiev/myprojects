namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            if (this.Cards.Count == 0)
            {
                return string.Empty;
            }

            string hand = string.Join(" ", this.Cards);
            return hand.ToString();
        }
    }
}
