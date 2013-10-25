namespace KingSurvival
{
    using System;

    public class PawnD : Pawn
    {
        private string[] validPawnInputs = 
        { 
            "DDL", 
            "DDR" 
        };

        private bool[,] pawnExistingMoves = 
        {
            { true, true }
        };

        private int[,] pawnsPosition = 
        {
            { 2, 16 }
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
