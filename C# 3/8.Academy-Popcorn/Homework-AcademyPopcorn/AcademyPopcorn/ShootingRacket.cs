/* Inherit the Engine class. Create a method ShootPlayerRacket. Leave it empty for now. 
 * 
 *Implement a shoot ability for the player racket. The ability should only be activated
 *when a Gift object falls on the racket. The shot objects should be a new class (e.g. Bullet)
 *and should destroy normal Block objects (and be destroyed on collision with any block). 
 *Use the engine and ShootPlayerRacket method you implemented in task 4, but don't add items
 *in any of the engine lists through the ShootPlayerRacket method. Also don't edit the Racket.cs file. 
 *
 * Hint: you should have a ShootingRacket class and override its ProduceObjects method. */

using System;

namespace AcademyPopcorn
{
    class ShootingRacket : Engine
    {
        public ShootingRacket(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        // I have no idea how to make it work correct :(
        public void ShootPlayerRacket()
        {
        }
    }
}
