using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (maxGrade <= minGrade)
        {
            throw new ApplicationException("Minimum grade can not be grater from maximum grade.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade; 
        }

        private set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Grade can not be less from 0.");
            }

            this.grade = value; 
        }
    }

    public int MinGrade
    {
        get 
        {
            return this.minGrade; 
        }

        private set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Minimum grade can not be less from 0.");
            }

            this.minGrade = value; 
        }
    }

    public int MaxGrade
    {
        get 
        {
            return this.maxGrade; 
        }

        private set 
        {
            this.maxGrade = value; 
        }
    }

    public string Comments
    {
        get 
        {
            return this.comments; 
        }

        private set 
        {
            if (value == null || value == string.Empty)
            {
                throw new ArgumentException("Comment for exam result can not be empty or null.");
            }

            this.comments = value; 
        }
    }
}
