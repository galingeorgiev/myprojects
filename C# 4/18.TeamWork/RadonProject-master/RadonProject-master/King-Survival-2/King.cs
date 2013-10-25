namespace KingSurvival
{
    using System;

    public class King : Figure
    {
        private static string[] validKingInputs = 
        {                               
            "KUL",                                  
            "KUR",       
            "KDL", 
            "KDR" 
        };

        private static int[] kingPosition = 
        { 
            9, 
            10 
        };

        private static bool[] kingExistingMoves = 
        { 
            true, 
            true, 
            true, 
            true 
        };

        public static string[] ValidKingInputs
        {
            get
            {
                return validKingInputs;
            }
        }

        public static int[] KingPosition
        {
            get
            {
                return kingPosition;
            }

            set
            {
                kingPosition = value;
            }
        }

        public static bool[] KingExistingMoves
        {
            get
            {
                return kingExistingMoves;
            }

            set
            {
                kingExistingMoves = value;
            }
        }
    }
}
