/* Implement a GiftBlock class. It should be a block, which "drops" a Gift
 * object when it is destroyed. You must NOT edit any existing .cs file.
 * Test the Gift and GiftBlock classes by adding them through the
 * AcademyPopcornMain.cs file. */

using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            base.body = new char[,] { { 'G' } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObject = new List<GameObject>();
            if (this.IsDestroyed)
            {
                Gift newGift = new Gift(this.topLeft, new char[,] { { 'G' } });
                produceObject.Add(newGift);
            }
            
            return produceObject;
        }
    }
}
