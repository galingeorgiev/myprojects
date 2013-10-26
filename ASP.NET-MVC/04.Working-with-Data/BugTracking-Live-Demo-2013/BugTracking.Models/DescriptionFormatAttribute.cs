using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringContainsAttribute : ValidationAttribute
    {
        private string text;

        public StringContainsAttribute(string text)
        {
            this.text = text;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return true;
            }

            return valueAsString.Contains(text);
        }
    }
}
