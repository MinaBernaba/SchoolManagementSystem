using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api/";
        public const string version = "V1/";
        public const string rule = root + version;
        public static class Student
        {
            public const string Prefix = rule + "Student/";
            public const string GetAllStudents = Prefix + "GetAllStudents";
            public const string GetStudentById = Prefix + "GetStudentById/{id}";
            public const string CreateStudent = Prefix + "Create";
        }
    }
}