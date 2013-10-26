using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CF.Model
{
    public class UniversityCFTest
    {
        [Key]
        public int IniveristyID { get; set; }
        public string Name { get; set; }
        private ICollection<StudentsCFTest> students;

        public UniversityCFTest()
        {
            students = new HashSet<StudentsCFTest>();
        }

        public virtual ICollection<StudentsCFTest> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
        
    }
}
