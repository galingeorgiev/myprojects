namespace School.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        private ICollection<Course> courses;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public virtual ICollection<Course> Course
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
