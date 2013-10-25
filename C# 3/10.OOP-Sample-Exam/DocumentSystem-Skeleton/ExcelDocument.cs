using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        private int numberOfRows;
        private int numberOfCols;

        public int NumberOfCols
        {
            get { return numberOfCols; }
            set { numberOfCols = value; }
        }
        

        public int NumberOfRows
        {
            get { return numberOfRows; }
            set { numberOfRows = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.numberOfRows = int.Parse(value);
            }
            else if (key == "cols")
            {
                this.numberOfCols = int.Parse(value);
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
