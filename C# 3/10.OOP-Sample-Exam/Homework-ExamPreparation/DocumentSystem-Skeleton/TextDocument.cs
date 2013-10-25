using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        private string charSet;

        public string CharSet
        {
            get { return charSet; }
            set { charSet = value; }
        }

        public void ChangeContent(string newContent)
        {
            base.content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "charset")
            {
                this.charSet = value;
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
    }
}
