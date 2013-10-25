using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        private ulong? size;

        public ulong? Size
        {
            get { return size; }
            protected set { size = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "size")
            {
                this.size = ulong.Parse(value);
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
