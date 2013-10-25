namespace KnapsackProblem
{
    public class Product
    {
        private string name;
        private int weight;
        private int cost;

        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public int Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}: weight: {1}, cost: {2}", this.Name, this.Weight, this.Cost);
        }
    }
}
