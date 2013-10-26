using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CF.Model
{
    public class StudentsCFTest
    {
        [Key]
        public int StudentId { get; set; }
        public int UniversityId { get; set; }
    }
}
