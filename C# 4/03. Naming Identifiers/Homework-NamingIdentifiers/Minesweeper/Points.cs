namespace Minesweeper
{
    public class Points
    {
        private string name;
        private int point;

        public Points() 
        {
        }

        public Points(string name, int point)
        {
            this.name = name;
            this.point = point;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Point
        {
            get { return this.point; }
            set { this.point = value; }
        }
    }
}
