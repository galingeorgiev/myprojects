namespace KingSurvival
{
    using System;

    public class PawnB : Pawn
    {
        // fields
        private readonly string[] validPawnInputs = 
        { 
            "BDL", 
            "BDR" 
        };

        private int[,] pawnsPosition = 
        {
            { 2, 8 }
        };

        private bool[,] pawnExistingMoves = 
        {
            { true, true }
        };

        // properties
        public override int[,] PawnsPosition
        {
            get
            {
                return this.pawnsPosition;
            }
            set
            {
                this.pawnsPosition = value;
            }
        }

        public bool[,] PawnExistingMoves
        {
            get
            {
                return this.pawnExistingMoves;
            }
            set
            {
                this.pawnExistingMoves = value;
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
