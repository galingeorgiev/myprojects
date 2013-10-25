namespace KingSurvivalGame
{
    using System;
    using KingSurvival;

    class KingSurvivalGame
    {
        static void Main()
        {
            GameLogic gameTester = new GameLogic();
            gameTester.InteractWithUser();
            Console.WriteLine("\nThank you for using this game!\n\n");
        }
    }
}