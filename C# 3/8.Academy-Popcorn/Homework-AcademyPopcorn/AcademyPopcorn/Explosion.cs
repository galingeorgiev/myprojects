using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class Explosion : MovingObject
    {
        public Explosion(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] {{'+'}}, speed)
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }
        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
