using System;
using System.Text;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class PDFDocument : BinaryDocument, IEncryptable
    {
        private int? numberOfPages;
        private bool isEncrypted = false;

        public int? NumberOfPages
        {
            get { return numberOfPages; }
            set { numberOfPages = value; }
        }

        public bool IsEncrypted
        {
            get { return this.isEncrypted; }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.numberOfPages = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            foreach (var property in output)
            {
                this.LoadProperty(property.Key, property.Value.ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.isEncrypted)
            {
                result.Append("Document encrypted: ");
                result.Append(this.Name);
                return result.ToString();
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
