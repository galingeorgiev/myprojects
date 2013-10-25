/* Implement an ExplodingBlock. It should destroy all blocks around
 * it when it is destroyed. You must NOT edit any existing .cs file. 
 * Hint: what does an explosion "produce"? */

using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft) : base(topLeft)
        {
            base.body = new char[,] { { '@' } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Explosion> removedBlocks = new List<Explosion>();
            if (this.IsDestroyed)
            {
                removedBlocks.Add(new Explosion(this.topLeft, new MatrixCoords(-1, -1)));
                removedBlocks.Add(new Explosion(this.topLeft, new MatrixCoords(-1, 0)));
                removedBlocks.Add(new Explosion(this.topLeft, new MatrixCoords(-1, 1)));
                removedBlocks.Add(new Explosion(this.topLeft, new MatrixCoords(0, -1)));
                removedBlocks.Add(new Explosion(this.topLeft, new MatrixCoords(0, 1)));
                removedBlocks.Add(new Explosion(this.topLeft, new MatrixCoords(1, -1)));
                removedBlocks.Add(new Explosion(this.topLeft, new MatrixCoords(1, 0)));
                removedBlocks.Add(new Explosion(this.topLeft, new MatrixCoords(1, 1)));
            }
            return removedBlocks;
        }
        /*private IEnumerable<ExplodingBlock> AddObjectForRemove()
        {
        List<ExplodingBlock> removedBlocks = new List<ExplodingBlock>()
        {
        new Explosion(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col - 1)),
        new Explosion(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col)),
        new Explosion(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col + 1)),
        new Explosion(new MatrixCoords(this.topLeft.Row, this.topLeft.Col - 1)),
        new Explosion(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 1)),
        new Explosion(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col - 1)),
        new Explosion(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col)),
        new Explosion(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col + 1))
        };
        return removedBlocks;
        }*/
    }
}