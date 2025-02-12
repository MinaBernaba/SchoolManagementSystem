using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities.DbTables
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public int? Period { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }

    }
}
