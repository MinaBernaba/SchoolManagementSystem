﻿using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>();
        }
    }
}
