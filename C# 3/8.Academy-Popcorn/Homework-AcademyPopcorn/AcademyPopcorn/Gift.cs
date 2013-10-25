/* Implement a Gift class. It should be a moving object, which always
 * falls down. The gift shouldn't collide with any ball, but should
 * collide (and be destroyed) with the racket. You must NOT edit any
 * existing .cs file. */

using System;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        public new const string CollisionGroupString = "block";

        public Gift(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body, new MatrixCoords(1,0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Block.CollisionGroupString;
        }
    }
}
