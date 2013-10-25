using System;
using System.Text;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class OfficeDocument : BinaryDocument, IEncryptable
    {
        private string version;
        private bool isEncrypted = false;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.version = value;
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

        //public override string ToString()
        //{
        //    StringBuilder result = new StringBuilder();
        //    if (this.isEncrypted)
        //    {
        //        result.Append("Document encrypted: ");
        //        result.Append(this.Name);
        //    }
        //    else
        //    {
        //        base.ToString();
        //    }
        //    return result.ToString();
        //}
    }
}
