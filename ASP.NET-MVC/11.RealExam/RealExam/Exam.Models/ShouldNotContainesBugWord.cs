using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ShouldNotContainesBugWord : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string title = value as string;

            if (title.ToLower().Contains("bug"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
