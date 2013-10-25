using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocuments
    {
        private double frameRate;

        public double FrameRate
        {
            get { return frameRate; }
            set { frameRate = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.frameRate = double.Parse(value);
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
