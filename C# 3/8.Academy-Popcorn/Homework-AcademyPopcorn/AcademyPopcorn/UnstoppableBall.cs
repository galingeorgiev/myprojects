/* Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces
 * off UnpassableBlocks and will destroy any other block it passes through. The
 * UnpassableBlock should be indestructible.
 * 
 * Hint: Take a look at the RespondToCollision method, the GetCollisionGroupString method and the CollisionData class. */

using System;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block" ||
                otherCollisionGroupString == "unpassableBlock" || otherCollisionGroupString == "indestructibleBlock";
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings[0] != "block")
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {
                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.Speed.Col *= -1;
                }
            }
        }
    }
}
