using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities.DbTables
{
    public class Student
    {
        public int StudentId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }

        public int DepartmentId { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual Department Department { get; set; }
    }
}
