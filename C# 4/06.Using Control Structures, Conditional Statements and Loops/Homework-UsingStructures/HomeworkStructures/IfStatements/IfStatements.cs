namespace IfStatements
{
    using System;
    using StraightLine;

    public class IfStatements
    {
        private const int MaxX = 100;
        private const int MinX = 0;
        private const int MaxY = 100;
        private const int MinY = 0;

        public static bool isVisitCell { get; set; }

        public static void VisitCell()
        {
            throw new NotImplementedException();
        }

        public static void Main()
        {
            // Task 1 from homework.
            Potato potato = new Potato();
            if (potato != null)
            {
                if (potato.HasBeenPeeled && !potato.IsRotten)
                {
                    Chef chefForTestCook = new Chef();

                    // I change Cook(potato) to chefForTestCook.Cook();
                    // because method Cook doen not accept arguments.
                    chefForTestCook.Cook();
                }
            }

            // Task 2 from homework.
            int x = 5;
            int y = 10;

            // Names aren't perfect, but I don't know what condition they check.
            bool isXConditionTrue = x >= MinX;
            bool isOtherConditionTrue = (x <= MaxX) && (MaxY >= y && MinY <= y);
            if (isXConditionTrue && isOtherConditionTrue && isVisitCell)
            {
                VisitCell();
            }
        }
    }
}