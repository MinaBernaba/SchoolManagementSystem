using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } 
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

    }
}
