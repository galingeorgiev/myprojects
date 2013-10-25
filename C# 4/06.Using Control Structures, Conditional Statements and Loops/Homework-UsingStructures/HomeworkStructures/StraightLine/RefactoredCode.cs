namespace StraightLine
{
    using System;

    public class Chef
    {
        // Documentation isn't added because that is not a task.
        public void Cook()
        {
            // Get products.
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();

            // Peel products.
            this.Peel(potato);
            this.Peel(carrot);

            // Cut products.
            this.Cut(potato);
            this.Cut(carrot);

            // Create Bowl and add products
            Bowl bowl = this.GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Potato GetPotato()
        {
            // ...
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            // ...
            throw new NotImplementedException();
        }

        private void Peel(Vegetable vegetable)
        {
            // ... 
            throw new NotImplementedException();
        }

        private void Cut(Vegetable potato)
        {
            // ...
            throw new NotImplementedException();
        }

        private Bowl GetBowl()
        {
            // ... 
            throw new NotImplementedException();
        }
    }

    public class RefactoredCode
    {
        public static void Main()
        {
        }
    }
}