using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved; 
        }

        private set 
        {
            if (value < 0 || value >= 3)
            {
                throw new ArgumentException("problem solved must be between 0 and 2.");
            }

            this.problemsSolved = value; 
        }
    }

    public override ExamResult Check()
    {
        switch (this.problemsSolved)
        {
            case 0:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 1:
                return new ExamResult(4, 2, 6, "Average result: nothing done.");
            case 2: 
                return new ExamResult(6, 2, 6, "Average result: nothing done.");
            default:
                return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
        }
    }
}
