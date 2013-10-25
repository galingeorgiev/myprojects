/* Implement a TrailObject class. It should inherit the GameObject class and
 * should have a constructor which takes an additional "lifetime" integer.
 * The TrailObject should disappear after a "lifetime" amount of turns.
 * You must NOT edit any existing .cs file. Then test the TrailObject by
 * adding an instance of it in the engine through the AcademyPopcornMain.cs file. */

using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        private int lifetime;

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            lifetime--;
            //this.UpdatePosition();
            if (lifetime == 0)
            {
                this.IsDestroyed = true;
            }
        }
        /*
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return TrailObject.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
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

        private void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }
         */
    }
}
