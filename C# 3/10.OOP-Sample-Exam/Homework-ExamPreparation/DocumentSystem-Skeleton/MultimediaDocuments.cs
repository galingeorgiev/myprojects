using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class MultimediaDocuments : BinaryDocument
    {
        private int length;

        public int Length
        {
            get { return length; }
            protected set { length = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "length")
            {
                this.length = int.Parse(value);
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
