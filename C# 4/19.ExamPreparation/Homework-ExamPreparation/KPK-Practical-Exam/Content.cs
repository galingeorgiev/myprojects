namespace CatalogOfFreeContent
{
    using System;

    public class Content : IComparable, IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        private string url;

        public string URL
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            if (commandParams.Length < 2)
            {
                throw new ArgumentException("Parameters must have at least two arguments - title and author.");
            }

            this.Title = commandParams[(int)ItemContent.Title];
            this.Author = commandParams[(int)ItemContent.Author];

            if (commandParams.Length == 3)
            {
                this.Size = long.Parse(commandParams[(int)ItemContent.Size]);
            }

            if (commandParams.Length == 4)
            {
                this.Size = long.Parse(commandParams[(int)ItemContent.Size]);
                this.URL = commandParams[(int)ItemContent.Url];
            }
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                throw new NullReferenceException("Cannot compare null with object of type Content.");
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
