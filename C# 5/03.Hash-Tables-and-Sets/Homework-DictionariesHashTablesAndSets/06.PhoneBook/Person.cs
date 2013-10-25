namespace PhoneBook
{
    public class Person
    {
        private string name;
        private string town;
        private string phone;

        public Person(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Town
        {
            get { return this.town; }
            set { this.town = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public override string ToString()
        {
            return this.Name + " " + this.Town;
        }
    }
}
