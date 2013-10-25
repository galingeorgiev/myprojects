namespace KingSurvival
{
    using System;

    public class PawnA : Pawn
    {
        // fields
        private readonly string[] validPawnInputs = 
        { 
            "ADL", 
            "ADR" 
        };

        private static int[,] pawnsPosition = 
        {
            { 2, 4 }
        };

        private static bool[,] pawnExistingMoves = 
        {
            { true, true }
        };

        // properties
        public override int[,] PawnsPosition
        {
            get
            {
                return pawnsPosition;
            }

            set
            {
                pawnsPosition = value;
            }
        }

        public static bool[,] PawnExistingMoves
        {
            get
            {
                return pawnExistingMoves;
            }

            set
            {
                pawnExistingMoves = value;
            }
        }

        public override string[] ValidPawnInputs
        {
            get
            {
                return this.validPawnInputs;
            }
        }

        // methods
        public override bool MovePawn(string command)
        {
            throw new NotImplementedException();
        }
    }
}
