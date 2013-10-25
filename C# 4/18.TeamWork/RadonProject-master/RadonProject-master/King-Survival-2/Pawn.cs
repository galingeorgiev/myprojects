namespace KingSurvival
{
    using System;

    public abstract class Pawn : Figure
    {
        // fileds
        public abstract int[,] PawnsPosition { get; set; }

        public abstract bool MovePawn(string command);

        public abstract string[] ValidPawnInputs { get; }

        // TODO: Move pawnExistingMoves and its propertie to the inherited classes
        private static bool[,] pawnExistingMoves = 
        {
            { true, true }, 
            { true, true }, 
            { true, true }, 
            { true, true }
        };

        // properties
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
    }
}
