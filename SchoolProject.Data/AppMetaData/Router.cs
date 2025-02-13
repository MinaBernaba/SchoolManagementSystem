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
            public const string CreateStudent = Prefix + "CreateStudent";
            public const string UpdateStudent = Prefix + "UpdateStudent";
            public const string DeleteStudent = Prefix + "DeleteStudent/{id}";
            public const string GetPageOfStudents = Prefix + "GetPageOfStudents/";
        }

        public static class Department
        {
            public const string Prefix = rule + "Department/";
            public const string GetDepartmentById = Prefix + "GetDepartmentById/";
        }
        public static class User
        {
            public const string Prefix = rule + "User/";
            public const string AddNewUser = Prefix + "AddNewUser/";
            public const string GetAllUsersPaginated = Prefix + "GetAllUsersPaginated/";
            public const string GetUserById = Prefix + "GetUserById/{id}";
            public const string UpdateUser = Prefix + "UpdateUser";
            public const string ChangePassword = Prefix + "ChangePassword/";
            public const string DeleteUser = Prefix + "DeleteUser/{id}";
        }
    }
}