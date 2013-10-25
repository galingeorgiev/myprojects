/* Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces
 * off UnpassableBlocks and will destroy any other block it passes through. The
 * UnpassableBlock should be indestructible.
 * 
 * Hint: Take a look at the RespondToCollision method, the GetCollisionGroupString method and the CollisionData class. */

using System;

namespace AcademyPopcorn
{
    class UnpassableBlock : Block
    {
        public const char Symbol = '^';
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;

        }
        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
        }
    }
}
