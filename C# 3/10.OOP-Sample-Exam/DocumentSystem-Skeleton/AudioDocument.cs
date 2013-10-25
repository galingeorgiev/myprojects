using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocuments
    {
        private double sampleRate;

        public double SampleRate
        {
            get { return sampleRate; }
            set { sampleRate = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.sampleRate = double.Parse(value);
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
