using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities.DbTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void AddStudentMapper()
        {
            CreateMap<AddStudentCommand, Student>();
        } 
    }
}
