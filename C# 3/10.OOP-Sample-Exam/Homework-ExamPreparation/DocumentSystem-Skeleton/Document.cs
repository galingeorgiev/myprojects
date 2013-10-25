using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        private string name;
        protected string content;
        protected List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public string Content
        {
            get { return this.content; }
            protected set { this.content = value; }
        }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.name = value;
            }
            else if (key == "content")
            {
                this.content = value;
            }

            if (key != null & value != null)
            {
                KeyValuePair<string, object> input = new KeyValuePair<string, object>(key, value);
                this.properties.Add(input);
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            foreach (var property in output)
            {
                this.LoadProperty(property.Key, property.Value.ToString());
            }
        }

        public override string ToString()
        {
            //List<KeyValuePair<string, object>> properties =
            //new List<KeyValuePair<string, object>>();
            //this.SaveAllProperties(properties);
            properties.Sort((a, b) => a.Key.CompareTo(b.Key));
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append("[");
            bool first = true;
            foreach (var prop in properties)
            {
                if (prop.Value != null)
                {
                    if (!first)
                    {
                        result.Append(";");
                    }
                    result.AppendFormat("{0}={1}", prop.Key, prop.Value);
                    first = false;
                }
            }
            result.Append("]");
            return result.ToString();
        }
    }
}
