using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.CQRS.Departments.Queries.Responses
{
    public class GetDepartmentByIdWithDetailsResponse
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }
        public PaginatedResult<StudentResponse> StudentsList { get; set; }
        public IEnumerable<SubjectResponse> SubjectsList { get; set; }
        public IEnumerable<InstructorResponse> InstructorsList { get; set; }
    }
    public class StudentResponse
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
    }
    public class InstructorResponse
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
    }
}
