using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public int? InstructorManagerId { get; set; }
        public virtual Instructor InstructorManager { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
