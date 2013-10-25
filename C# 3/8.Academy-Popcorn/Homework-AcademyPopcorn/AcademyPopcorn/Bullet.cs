/* The shot objects should be a new class (e.g. Bullet) and should destroy
 * normal Block objects (and be destroyed on collision with any block). */

using System;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        public Bullet(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '*' } }, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Bullet.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            IsDestroyed = true;
        }
    }
}
