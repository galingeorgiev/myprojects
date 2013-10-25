using System;
using System.Linq;

namespace DocumentSystem
{
    
    struct BibaryDocument : IComparable
    {
        private string document;

        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        //public BibaryDocument()
        //{

        //}

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
    class TextDocument
    {
        static void Main()
        {
            BibaryDocument bd = new BibaryDocument();
        }
    }
}
