using System;

namespace AboutPhone
{
    public class Display
    {
        private float size; //read only
        private int colors; //read only

        //Define constructors (empty)
        public Display(float size, int colors)
        {
            isDisplaySizeCorrect(size);
            isDisplayColorsCorrect(colors);
            this.size = size;
            this.colors = colors;
        }

        //Define properties
        public float Size
        {
            get { return this.size; }
        }

        public int Colors
        {
            get { return this.colors; }
        }

        //Methods that check input information
        private static void isDisplaySizeCorrect(float size)
        {
            if (size <= 2)
            {
                throw new ApplicationException("Dispaly size must be more from 2\"");
            }
        }

        private static void isDisplayColorsCorrect(int colors)
        {
            if (colors < 255)
            {
                throw new ApplicationException("Dispaly colors must be more from 255\"");
            }
        }
    }
}
